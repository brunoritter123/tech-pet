using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using TechPet.API.Results;

namespace TechPet.API.Abstractions
{
    public static class ProducesResponseConvention
    {
        //[ProducesResponseType(typeof(ResultDefault<IEnumerable<WeatherForecast>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResultDefault), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResultDefault), StatusCodes.Status500InternalServerError)]
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
        public static void Default() { }
    }
}
