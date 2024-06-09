using DefaultProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DefaultProject.Domain.Abstractions;

public interface IDbContext
{
    public DbSet<WeatherForecast> WeatherForecasts { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}