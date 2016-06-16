using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Nightscout.Models;

namespace Nightscout.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class StatusApiController : Controller
    {
        /// <summary>
        /// Status
        /// </summary>
        /// <remarks>Server side status, default settings and capabilities.</remarks>
        /// <response code="200">Server capabilities and status.</response>
        /// <response code="0">Unexpected error</response>
        [HttpGet]
        [Route("/status")]
        //[SwaggerOperation("StatusGet")]
        //[SwaggerResponse(200, type: typeof(Status))]
        public IActionResult StatusGet()
        {
            string exampleJson = null;

            var example = exampleJson != null
                ? JsonConvert.DeserializeObject<Status>(exampleJson)
                : default(Status);

            return new ObjectResult(example);
        }
    }
}