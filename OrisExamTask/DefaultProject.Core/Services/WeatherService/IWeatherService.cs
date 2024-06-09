using DefaultProject.Contracts.Requests.GetWeather;
using DefaultProject.Domain.Requests.AddWeather;
using DefaultProject.Domain.Requests.EditWeather;
using DefaultProject.Domain.Requests.GetWeather;

namespace DefaultProject.Domain.Services.WeatherService;

public interface IWeatherService
{
    public Task<GetWeatherResponse> GetWeatherByDateAsync(
        GetWeatherRequest request,
        CancellationToken cancellationToken);

    public Task<Guid> AddWeatherAsync(
        AddWeatherRequest request,
        CancellationToken cancellationToken);

    public Task RemoveWeatherAsync(
        Guid id,
        CancellationToken cancellationToken);

    public Task EditWeatherAsync(
        Guid id,
        EditWeatherRequest request,
        CancellationToken cancellationToken);
}