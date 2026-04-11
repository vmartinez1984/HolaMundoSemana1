using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;
using wschools;

namespace HolaMundo.ConsumoSoap.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("Temperaturas")]
        public async Task<IActionResult> GetTemperaturas()
        {
            TempConvertSoap client = new TempConvertSoapClient(
                TempConvertSoapClient.EndpointConfiguration.TempConvertSoap
            );
            var response = await client.CelsiusToFahrenheitAsync("100");
            return Ok(response);
        }
    }
}
