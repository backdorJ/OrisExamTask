using DefaultProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DefaultProject.DAL.PostgreSQL.Configuration;

public class WeatherForecastConfiguration : IEntityTypeConfiguration<WeatherForecast>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<WeatherForecast> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(p => p.Date)
            .IsRequired();

        builder.Property(p => p.TemperatureC)
            .IsRequired();

        builder.Property(p => p.TemperatureF)
            .IsRequired();

        builder.Property(p => p.Summary);

        builder.Property(p => p.FirstName)
            .IsRequired();

        builder.Property(p => p.LastName)
            .IsRequired();

        builder.Property(p => p.FullName)
            .ValueGeneratedOnAddOrUpdate();

        builder.Property(p => p.City)
            .IsRequired();
    }
}