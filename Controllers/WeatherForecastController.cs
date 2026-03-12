using Microsoft.AspNetCore.Mvc;

namespace OpenApiIssue.Controllers;

[ApiController, Route("[controller]")]
public class WeatherForecastController : ControllerBase {
    [HttpPost("forecasts", Name = "GetWeatherForecast"), 
     Consumes(typeof(WeatherForecasts), "application/vnd.example.forecasts+xml", "application/vnd.example.forecasts+json"),
     ProducesResponseType<WeatherForecasts>(
	     StatusCodes.Status200OK,
		 "application/vnd.example.forecasts+xml",
	     "application/vnd.example.forecasts+json")]
    public IActionResult Get(WeatherForecasts forecasts) {
        return new ObjectResult(forecasts);
    }

    [HttpPost("forecasts2", Name = "GetWeatherForecast2"),
     Consumes(typeof(WeatherForecasts2), "application/vnd.example.forecasts2+xml", "application/vnd.example.forecasts2+json"),
     ProducesResponseType<WeatherForecasts2>(
	     StatusCodes.Status200OK,
	     "application/vnd.example.forecasts2+xml",
	     "application/vnd.example.forecasts2+json")]
    public IActionResult Get2(WeatherForecasts2 forecasts)
    {
	    return new ObjectResult(forecasts);
    }
}
