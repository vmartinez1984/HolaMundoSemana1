using Microsoft.AspNetCore.Mvc;

namespace HolaMundo.Middleware.v1.Controllers
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
        public IActionResult Get([FromHeader] string? apikey)
        {
            //var header = this.HttpContext.Request.Headers.Where(x=> x.Key == "apikey").FirstOrDefault();
            //var existHeader = this.HttpContext.Request.Headers.TryGetValue("apikey", out var value);
            //if (!existHeader)
            //{
            //    ProblemDetails problemDetails = new ProblemDetails
            //    {
            //        Title = "Unauthorized",
            //        Detail = "No se ingreso la apikey",
            //        Status = StatusCodes.Status401Unauthorized
            //    };
            //    return Unauthorized(problemDetails);
            //}

            //if(value != "1234")
            //{
            //    ProblemDetails problemDetails = new ProblemDetails
            //    {
            //        Title = "Unauthorized",
            //        Detail = "La apikey es incorrecta",
            //        Status = StatusCodes.Status401Unauthorized
            //    };
            //    return Unauthorized(problemDetails);
            //}

            var array = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

            return Ok(array);
        }
    }
}
