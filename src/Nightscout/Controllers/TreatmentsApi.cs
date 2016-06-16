using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Nightscout.Models;


namespace Nightscout.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class TreatmentsApiController : Controller
    {
        /// <summary>
        /// Add new treatments.
        /// </summary>
        /// <remarks></remarks>
        /// <param name="body">Treatments to be uploaded.</param>
        /// <response code="200">Rejected list of treatments.  Empty list is success.</response>
        /// <response code="405">Invalid input</response>
        [HttpPost]
        [Route("/treatments")]
        //[SwaggerOperation("AddTreatments")]
        public void AddTreatments([FromBody] Treatments body)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Treatments
        /// </summary>
        /// <remarks>The Treatments endpoint returns information about the Nightscout treatments.</remarks>
        /// <param name="find">The query used to find entries, supports nested query syntax.  Examples `find[insulin][$gte]=3` `find[carb][$gte]=100` `find[eventType]=Correction+Bolus` All find parameters are interpreted as strings.</param>
        /// <param name="count">Number of entries to return.</param>
        /// <response code="200">An array of treatments</response>
        /// <response code="0">Unexpected error</response>
        [HttpGet]
        [Route("/treatments")]
        //[SwaggerOperation("TreatmentsGet")]
        //[SwaggerResponse(200, type: typeof(Treatments))]
        public IActionResult TreatmentsGet([FromQuery] string find, [FromQuery] double? count)
        {
            string exampleJson = null;

            var example = exampleJson != null
                ? JsonConvert.DeserializeObject<Treatments>(exampleJson)
                : default(Treatments);

            return new ObjectResult(example);
        }
    }
}