using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using Newtonsoft.Json;
using Nightscout.Binders;
using Nightscout.Entitites;
using Nightscout.Models;

namespace Nightscout.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class EntriesController : Controller
    {
        private readonly IMongoDatabase _database;
        private readonly ILogger<EntriesController> _logger;

        public EntriesController(IMongoDatabase database, ILogger<EntriesController> logger)
        {
            _database = database;
            _logger = logger;
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
            var collection = this._database.GetCollection<EntryEntity>("entries");

            var query = CreateQuery(find);
            var results = await collection.Find(query).SortByDescending(s => s.Date).Limit(20).ToListAsync();

            return new ObjectResult(results);
        }

        private static FilterDefinition<EntryEntity> CreateQuery(QueryFilter query)
        {
            var filter =  Builders<EntryEntity>.Filter;
            var hasType = false;

            var list = new List<FilterDefinition<EntryEntity>>();
            foreach (var item in query.Filters)
            {
                switch (item.Field.ToLowerInvariant().Trim())
                {
                    case "type":
                        list.Add(filter.Eq(e => e.Type, item.Value));
                        hasType = true;
                        break;
                }
            }

            if (!hasType)
            {
                filter = filter.And()Eq(f => f.Type, "sgv");
            }

            return filter;
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
        public IActionResult EntriesSpecGet([FromRoute] string spec, [FromQuery] string find, [FromQuery] double? count)
        {
            string exampleJson = null;

            var example = exampleJson != null
                ? JsonConvert.DeserializeObject<Entries>(exampleJson)
                : default(Entries);

            return new ObjectResult(example);
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