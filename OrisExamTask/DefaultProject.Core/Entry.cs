using DefaultProject.Domain.Services.WeatherService;
using Microsoft.Extensions.DependencyInjection;

namespace DefaultProject.Domain;

public static class Entry
{
    public static void AddCore(this IServiceCollection services)
    {
        if (services is null)
            throw new ArgumentNullException(nameof(services));

        services.AddScoped<IWeatherService, WeatherService>();
    }
}