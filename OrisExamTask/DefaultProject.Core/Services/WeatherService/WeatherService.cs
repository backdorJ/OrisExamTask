using DefaultProject.Contracts.Requests.GetWeather;
using DefaultProject.Domain.Abstractions;
using DefaultProject.Domain.Entities;
using DefaultProject.Domain.Extensions;
using DefaultProject.Domain.Requests.AddWeather;
using DefaultProject.Domain.Requests.EditWeather;
using DefaultProject.Domain.Requests.GetWeather;
using Microsoft.EntityFrameworkCore;

namespace DefaultProject.Domain.Services.WeatherService;

public class WeatherService : IWeatherService
{
    private readonly IDbContext _dbContext;

    public WeatherService(IDbContext dbContext)
        => _dbContext = dbContext;

    /// <inheritdoc />
    public async Task<GetWeatherResponse> GetWeatherByDateAsync(
        GetWeatherRequest request,
        CancellationToken cancellationToken)
    {
        var allCount = await _dbContext.WeatherForecasts.CountAsync(cancellationToken);
        
        var temperatures = await _dbContext.WeatherForecasts
            .AsNoTracking()
            .Where(x =>
                string.IsNullOrEmpty(request.City)
                || x.City.ToLower().Contains(request.City!.ToLower()))
            .Where(x => request.DateFrom == null || x.Date >= request.DateFrom)
            .Where(x => request.DateTo == null || x.Date <= request.DateTo)
            .Select(x => new GetWeatherResponseItem
            {
                City = x.City,
                Summary = x.Summary,
                TemperatureC = x.TemperatureC,
                TemperatureF = x.TemperatureF,
                Date = x.Date
            })
            .OrderBy(x => x.TemperatureC)
            .SkipTake(request)
            .ToListAsync(cancellationToken);

        return new GetWeatherResponse(temperatures, allCount);
    }

    /// <inheritdoc />
    public async Task<Guid> AddWeatherAsync(AddWeatherRequest request, CancellationToken cancellationToken)
    {
        if (request.TemperatureC < -100 || request.TemperatureC > 80)
            throw new ApplicationException("Температура должна быть в диапазоне от -100 до 80");

        if (string.IsNullOrEmpty(request.FirstName)
            || string.IsNullOrEmpty(request.SecondName)
            || string.IsNullOrEmpty(request.City))
            throw new ApplicationException("Заполните обязательные поля");

        var weather = new WeatherForecast
        {
            Date = request.Date,
            TemperatureC = request.TemperatureC,
            TemperatureF = 32 + (int)(request.TemperatureC / 0.5556),
            Summary = request.Summary,
            FirstName = request.FirstName,
            LastName = request.SecondName,
            City = request.City,

        };
        
        await _dbContext.WeatherForecasts
            .AddAsync(weather, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return weather.Id;
    }

    /// <inheritdoc />
    public async Task RemoveWeatherAsync(
        Guid id,
        CancellationToken cancellationToken)
    {
        var weatherToDelete = await _dbContext.WeatherForecasts
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken)
            ?? throw new ArgumentNullException(nameof(id));

        _dbContext.WeatherForecasts.Remove(weatherToDelete);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task EditWeatherAsync(Guid id, EditWeatherRequest request, CancellationToken cancellationToken)
    {
        var weatherToUpdate = await _dbContext.WeatherForecasts
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken)
            ?? throw new ArgumentNullException(nameof(id));

        weatherToUpdate.FirstName = request.FirstName ?? weatherToUpdate.FirstName;
        weatherToUpdate.LastName = request.SecondName ?? weatherToUpdate.LastName;
        weatherToUpdate.City = request.City ?? weatherToUpdate.City;

        if (request.TemperatureC >= -100 && request.TemperatureC <= 80)
        {
            weatherToUpdate.TemperatureC = request.TemperatureC.Value;
            weatherToUpdate.TemperatureF = 32 + (int)(request.TemperatureC.Value / 0.5556);
        }

        weatherToUpdate.Date = request.Date ?? weatherToUpdate.Date;
        weatherToUpdate.Summary = request.Summary ?? weatherToUpdate.Summary;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}