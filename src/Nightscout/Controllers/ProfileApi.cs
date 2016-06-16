using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Nightscout.Models;

namespace Nightscout.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class ProfileApiController : Controller
    {
        /// <summary>
        /// Profile
        /// </summary>
        /// <remarks>The Profile endpoint returns information about the Nightscout Treatment Profiles.</remarks>
        /// <response code="200">An array of treatments</response>
        /// <response code="0">Unexpected error</response>
        [HttpGet]
        [Route("/profile")]
        //[SwaggerOperation("ProfileGet")]
        //[SwaggerResponse(200, type: typeof(Profile))]
        public IActionResult ProfileGet()
        {
            string exampleJson = null;

            var example = exampleJson != null
                ? JsonConvert.DeserializeObject<Profile>(exampleJson)
                : default(Profile);

            return new ObjectResult(example);
        }
    }
}