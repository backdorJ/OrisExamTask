using DefaultProject.DAL.PostgreSQL.Configuration;
using DefaultProject.Domain.Abstractions;
using DefaultProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DefaultProject.DAL.PostgreSQL;

public class EfContext : DbContext, IDbContext
{
    public EfContext(DbContextOptions<EfContext> options)
        : base(options)
    {
    }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new WeatherForecastConfiguration());
        base.OnModelCreating(modelBuilder);
    }

    /// <inheritdoc />
    public DbSet<WeatherForecast> WeatherForecasts { get; set; }
}