using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Newtonsoft.Json;
using Nightscout.Entitites;
using Nightscout.Models;
using Nightscout.Utilities;

namespace Nightscout.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class EntriesController : Controller
    {
        private const int CacheLimit = 288;
        private static readonly string KeyProperty = "type";

        private readonly IMongoDatabase _database;
        private readonly ILogger<EntriesController> _logger;
        private readonly IMemoryCache _localCache;

        public EntriesController(IMongoDatabase database, ILogger<EntriesController> logger, IMemoryCache localCache)
        {
            _database = database;
            _logger = logger;
            _localCache = localCache;
        }

        /// <summary>
        /// Add new entries.
        /// </summary>
        /// <remarks></remarks>
        /// <param name="body">Entries to be uploaded.</param>
        /// <response code="200">Rejected list of entries.  Empty list is success.</response>
        /// <response code="405">Invalid input</response>
        [HttpPost]
        //[SwaggerOperation("AddEntries")]
        public void AddEntries([FromBody] Entries body)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// View generated Mongo Query object
        /// </summary>
        /// <remarks>Information about the mongo query object created by the query.\n</remarks>
        /// <param name="storage">`entries`, or `treatments` to select the storage layer.\n</param>
        /// <param name="spec">entry id, such as `55cf81bc436037528ec75fa5` or a type filter such\nas `sgv`, `mbg`, etc.\nThis parameter is optional.\n</param>
        /// <param name="find">The query used to find entries, support nested query syntax, for\nexample `find[dateString][$gte]=2015-08-27`.  All find parameters\nare interpreted as strings.\n</param>
        /// <param name="count">Number of entries to return.</param>
        /// <response code="200">An array of entries</response>
        [HttpGet]
        [Route("/echo/{storage}/{spec}")]
        //[SwaggerOperation("EchoStorageSpecGet")]
        //[SwaggerResponse(200, type: typeof(MongoQuery))]
        public IActionResult EchoStorageSpecGet([FromRoute] string storage, [FromRoute] string spec,
            [FromQuery] string find, [FromQuery] double? count)
        {
            string exampleJson = null;

            var example = exampleJson != null
                ? JsonConvert.DeserializeObject<MongoQuery>(exampleJson)
                : default(MongoQuery);

            return new ObjectResult(example);
        }


        /// <summary>
        /// All Entries matching query
        /// </summary>
        /// <remarks>The Entries endpoint returns information about the Nightscout entries.</remarks>
        /// <param name="find">The query used to find entries, support nested query syntax, for example `find[dateString][$gte]=2015-08-27`.  All find parameters are interpreted as strings.</param>
        /// <param name="count">Number of entries to return.</param>
        /// <response code="200">An array of entries</response>
        /// <response code="0">Unexpected error</response>
        [HttpGet]
        //[SwaggerOperation("EntriesGet")]
        //[SwaggerResponse(200, type: typeof(Entries))]
        public async Task<IActionResult> Get(QueryFilter find, [FromQuery] int? count)
        {
            return await QueryWithCache(find, count, "sgv");
        }

        private async Task<IActionResult> QueryWithCache(QueryFilter find, int? count, string defaultKeyValue)
        {
            int extraFields;
            var keyField = GetKeyField(find, KeyProperty, defaultKeyValue, out extraFields);
            var cacheKey = $"entries-{keyField}";
            if (extraFields == 0 && count.GetValueOrDefault() <= CacheLimit) // TODO configure cache limit
            {
                List<EntryEntity> result;
                if (_localCache.TryGetValue(cacheKey, out result))
                {
                    _logger.LogDebug("Returning query from cache with key {0}", cacheKey);
                    if (count.HasValue && count < CacheLimit)
                    {
                        _logger.LogDebug("Limiting cache results to {0} entries", count);
                        result = result.OrderByDescending(r => r.Date).Take(count.Value).ToList();
                    }

                    return new ObjectResult(result);
                }
            }

            var collection = this._database.GetCollection<EntryEntity>("entries");
            var query = CreateQuery<EntryEntity>(find, KeyProperty, defaultKeyValue, ConvertDateQuery);
            var results = await collection.Find(query).SortByDescending(s => s.Date).Limit(count).ToListAsync();

            // Populate cache for now if value equals max count
            if (extraFields == 0 && count.GetValueOrDefault() == CacheLimit)
            {
                _localCache.Set(cacheKey, results);
            }

            return new ObjectResult(results);
        }

        private static Tuple<string, object> ConvertDateQuery(string name, string value)
        {
            // Convert date string to more performant query
            if (string.Equals(name, "datestring", StringComparison.OrdinalIgnoreCase))
            {
                return new Tuple<string, object>("date", value.ToJavaScriptDate());
            }

            return null;
        }

        private static string GetKeyField(QueryFilter filter, string fieldName, string defaultValue, out int additionalFieldCount)
        {
            additionalFieldCount = 0;
            foreach (var item in filter.Filters)
            {
                if (string.Equals(item.Field, fieldName))
                {
                    return item.Value;
                }
                else
                {
                    additionalFieldCount++;
                }
            }

            return defaultValue;
        }

        private static FilterDefinition<TEntity> CreateQuery<TEntity>(QueryFilter query, string keyField, string defaultValue, 
            Func<string, string, Tuple<string, object>> remapFilter = null) where TEntity : class
        {
            var filter =  Builders<TEntity>.Filter;
            var hasType = false;

            var list = new List<FilterDefinition<TEntity>>();
            var reflectCache = GetFieldMapping<TEntity>();
            
            foreach (var item in query.Filters)
            {
                var fieldName = item.Field;
                object fieldValue = item.Value;
                var remap = remapFilter?.Invoke(fieldName, item.Value);
                if (remap != null)
                {
                    fieldName = remap.Item1;
                    fieldValue = remap.Item2;
                }

                Tuple<Type, object> fieldDefinition;
                if (!reflectCache.TryGetValue(fieldName, out fieldDefinition))
                {
                    throw new InvalidOperationException($"Cannot locate query field: {fieldName}");
                }

                if (!hasType && string.Equals(fieldName, keyField, StringComparison.OrdinalIgnoreCase))
                {
                    hasType = true;
                }

                var method = filter.GetType().GetMethods().FirstOrDefault(m => 
                        string.Equals(m.Name, item.Comparitor, StringComparison.OrdinalIgnoreCase) && 
                        typeof(FieldDefinition<,>) == m.GetParameters().First().ParameterType.GetGenericTypeDefinition());

                var result = method?.MakeGenericMethod(fieldDefinition.Item1)
                    .Invoke(filter, new[] { fieldDefinition.Item2, fieldValue }) as FilterDefinition<TEntity>;

                if (result != null)
                {
                    list.Add(result);
                }
            }

            if (!hasType)
            {
                list.Add(filter.Eq(keyField, defaultValue));
            }

            if (list.Count > 1)
            {
                return filter.And(list);
            }

            return list.Count == 1 ? list.First() : filter.Empty;
        }

        private static IDictionary<string, Tuple<Type, object>> GetFieldMapping<TEntity>() where TEntity : class
        {
            var fieldMappings = new Dictionary<string, Tuple<Type, object>>(StringComparer.OrdinalIgnoreCase);

            var properties = typeof(TEntity).GetProperties();

            foreach (var propertyInfo in properties)
            {
                // Skip ID properties
                var idProp = propertyInfo.GetCustomAttribute<BsonIdAttribute>();
                if (idProp != null)
                {
                    continue;
                }

                var propertyName = propertyInfo.Name;
                var customName = GetNameForProperty(propertyInfo);

                var genericDef = typeof(StringFieldDefinition<,>);
                var specificDef = genericDef.MakeGenericType(typeof(TEntity), propertyInfo.PropertyType);
                var serializerType = typeof(IBsonSerializer<>).MakeGenericType(propertyInfo.PropertyType);
                var constructorInfo = specificDef.GetConstructors().First();
                var lambda = Expression.Lambda<Func<object>>(Expression.Convert(Expression.New(constructorInfo, Expression.Constant(customName, typeof(string)), Expression.Default(serializerType)), typeof(object)));
                
                var fieldDef = new Tuple<Type, object>(propertyInfo.PropertyType, lambda.Compile()());

                if (!fieldMappings.ContainsKey(propertyName))
                {
                    fieldMappings.Add(propertyName, fieldDef);
                }

                if (!string.Equals(customName, propertyName, StringComparison.OrdinalIgnoreCase) &&
                    !fieldMappings.ContainsKey(customName))
                {
                    fieldMappings.Add(customName, fieldDef);
                }
            }

            return fieldMappings;
        }

        private static string GetNameForProperty(MemberInfo propertyInfo)
        {
            var customName = propertyInfo.Name;

            var bsonAttribute = propertyInfo.GetCustomAttribute<BsonElementAttribute>();
            if (bsonAttribute != null)
            {
                customName = bsonAttribute.ElementName;
            }
            return customName;
        }


        /// <summary>
        /// All Entries matching query
        /// </summary>
        /// <remarks>The Entries endpoint returns information about the\nNightscout entries.\n</remarks>
        /// <param name="spec">entry id, such as `55cf81bc436037528ec75fa5` or a type filter such\nas `sgv`, `mbg`, etc.\n</param>
        /// <param name="find">The query used to find entries, support nested query syntax, for\nexample `find[dateString][$gte]=2015-08-27`.  All find parameters\nare interpreted as strings.\n</param>
        /// <param name="count">Number of entries to return.</param>
        /// <response code="200">An array of entries</response>
        /// <response code="0">Entries</response>
        [HttpGet("/{spec}")]
        //[SwaggerOperation("EntriesSpecGet")]
        //[SwaggerResponse(200, type: typeof(Entries))]
        public async Task<IActionResult> EntriesSpecGet([FromRoute] string spec, QueryFilter find, [FromQuery] int? count)
        {
            return await QueryWithCache(find, count, spec);
        }


        /// <summary>
        /// Delete entries matching query.
        /// </summary>
        /// <remarks>Remove entries, same search syntax as GET.</remarks>
        /// <param name="find">The query used to find entries, support nested query syntax, for example `find[dateString][$gte]=2015-08-27`.  All find parameters are interpreted as strings.</param>
        /// <param name="count">Number of entries to return.</param>
        /// <response code="200">Empty list is success.</response>
        [HttpDelete]
        //[SwaggerOperation("Remove")]
        public void Remove([FromQuery] string find, [FromQuery] double? count)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// All Entries matching query
        /// </summary>
        /// <remarks>The Entries endpoint returns information about the Nightscout entries.</remarks>
        /// <param name="storage">Prefix to use in constructing a prefix-based regex, default is `entries`.</param>
        /// <param name="field">Name of the field to use Regex against in query object, default is `dateString`.</param>
        /// <param name="type">The type field to search against, default is sgv.</param>
        /// <param name="prefix">Prefix to use in constructing a prefix-based regex.</param>
        /// <param name="regex">Tail part of regexp to use in expanding/construccting a query object.\nRegexp also has bash-style brace and glob expansion applied to it,\ncreating ways to search for modal times of day, perhaps using\nsomething like this syntax: `T{15..17}:.*`, this would search for\nall records from 3pm to 5pm.\n</param>
        /// <param name="find">The query used to find entries, support nested query syntax, for\nexample `find[dateString][$gte]=2015-08-27`.  All find parameters\nare interpreted as strings.\n</param>
        /// <param name="count">Number of entries to return.</param>
        /// <response code="200">An array of entries</response>
        /// <response code="0">Unexpected error</response>
        [HttpGet]
        [Route("/slice/{storage}/{field}/{type}/{prefix}/{regex}")]
        //[SwaggerOperation("SliceStorageFieldTypePrefixRegexGet")]
        //[SwaggerResponse(200, type: typeof(Entries))]
        public IActionResult SliceStorageFieldTypePrefixRegexGet([FromRoute] string storage, [FromRoute] string field,
            [FromRoute] string type, [FromRoute] string prefix, [FromRoute] string regex, [FromQuery] string find,
            [FromQuery] double? count)
        {
            string exampleJson = null;

            var example = exampleJson != null
                ? JsonConvert.DeserializeObject<Entries>(exampleJson)
                : default(Entries);

            return new ObjectResult(example);
        }


        /// <summary>
        /// Echo the query object to be used.
        /// </summary>
        /// <remarks>Echo debug information about the query object constructed.</remarks>
        /// <param name="prefix">Prefix to use in constructing a prefix-based regex.</param>
        /// <param name="regex">Tail part of regexp to use in expanding/construccting a query object.\nRegexp also has bash-style brace and glob expansion applied to it,\ncreating ways to search for modal times of day, perhaps using\nsomething like this syntax: `T{15..17}:.*`, this would search for\nall records from 3pm to 5pm.\n</param>
        /// <param name="find">The query used to find entries, support nested query syntax, for example `find[dateString][$gte]=2015-08-27`.  All find parameters are interpreted as strings.</param>
        /// <param name="count">Number of entries to return.</param>
        /// <response code="200">An array of entries</response>
        /// <response code="0">Unexpected error</response>
        [HttpGet]
        [Route("/times/echo/{prefix}/{regex}")]
        //[SwaggerOperation("TimesEchoPrefixRegexGet")]
        //[SwaggerResponse(200, type: typeof(MongoQuery))]
        public IActionResult TimesEchoPrefixRegexGet([FromRoute] string prefix, [FromRoute] string regex,
            [FromQuery] string find, [FromQuery] double? count)
        {
            string exampleJson = null;

            var example = exampleJson != null
                ? JsonConvert.DeserializeObject<MongoQuery>(exampleJson)
                : default(MongoQuery);

            return new ObjectResult(example);
        }


        /// <summary>
        /// All Entries matching query
        /// </summary>
        /// <remarks>The Entries endpoint returns information about the Nightscout entries.</remarks>
        /// <param name="prefix">Prefix to use in constructing a prefix-based regex.</param>
        /// <param name="regex">Tail part of regexp to use in expanding/construccting a query object.\nRegexp also has bash-style brace and glob expansion applied to it,\ncreating ways to search for modal times of day, perhaps using\nsomething like this syntax: `T{15..17}:.*`, this would search for\nall records from 3pm to 5pm.\n</param>
        /// <param name="find">The query used to find entries, support nested query syntax, for example `find[dateString][$gte]=2015-08-27`.  All find parameters are interpreted as strings.</param>
        /// <param name="count">Number of entries to return.</param>
        /// <response code="200">An array of entries</response>
        /// <response code="0">Unexpected error</response>
        [HttpGet]
        [Route("/times/{prefix}/{regex}")]
        //[SwaggerOperation("TimesPrefixRegexGet")]
        //[SwaggerResponse(200, type: typeof(Entries))]
        public IActionResult TimesPrefixRegexGet([FromRoute] string prefix, [FromRoute] string regex,
            [FromQuery] string find, [FromQuery] double? count)
        {
            string exampleJson = null;

            var example = exampleJson != null
                ? JsonConvert.DeserializeObject<Entries>(exampleJson)
                : default(Entries);

            return new ObjectResult(example);
        }
    }
}