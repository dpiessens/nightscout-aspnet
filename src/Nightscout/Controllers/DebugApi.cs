using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Nightscout.Models;


namespace Nightscout.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class DebugApiController : Controller
    {
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
    }
}