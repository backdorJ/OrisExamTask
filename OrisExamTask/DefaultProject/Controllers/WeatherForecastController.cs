using DefaultProject.Contracts.Requests.GetWeather;
using DefaultProject.Domain.Requests.AddWeather;
using DefaultProject.Domain.Requests.EditWeather;
using DefaultProject.Domain.Requests.GetWeather;
using DefaultProject.Domain.Services.WeatherService;
using Microsoft.AspNetCore.Mvc;

namespace DefaultProject.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherService _weatherService;

    public WeatherForecastController(IWeatherService weatherService)
        => _weatherService = weatherService;

    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<GetWeatherResponse> GetWeatherAsync(
        [FromQuery] GetWeatherRequest request,
        CancellationToken cancellationToken)    
        => await _weatherService.GetWeatherByDateAsync(request, cancellationToken);

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(201)]
    public async Task<Guid> PostWeatherAsync(
        [FromBody] AddWeatherRequest request,
        CancellationToken cancellationToken)
        => await _weatherService.AddWeatherAsync(request, cancellationToken);

    [HttpDelete("{weatherId}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task RemoveWeatherAsync(
        [FromRoute] Guid weatherId,
        CancellationToken cancellationToken)
        => await _weatherService.RemoveWeatherAsync(weatherId, cancellationToken);

    [HttpPut("{weatherId}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task UpdateWeatherAsync(
        [FromRoute] Guid weatherId,
        [FromBody] EditWeatherRequest request,
        CancellationToken cancellationToken)
        => await _weatherService.EditWeatherAsync(weatherId, request, cancellationToken);
}