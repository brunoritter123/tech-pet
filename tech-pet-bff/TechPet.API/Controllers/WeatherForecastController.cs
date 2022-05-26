using Microsoft.AspNetCore.Mvc;
using TechPet.API.Results;
using TechPet.Domain.Abstractions.Notifications;

namespace TechPet.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    //[ApiConventionType(typeof(ProducesResponseConvention))]
    public class WeatherForecastController : ControllerBase
    {
        private readonly INotificacaoService _notificacao;

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, INotificacaoService notificacao)
        {
            _logger = logger;
            _notificacao = notificacao;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        [ProducesResponseType(typeof(ResultDefault<IEnumerable<WeatherForecast>>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {

            var teste = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

            return Ok(new ResultDefault<IEnumerable<WeatherForecast>>(teste));
        }
    }
}