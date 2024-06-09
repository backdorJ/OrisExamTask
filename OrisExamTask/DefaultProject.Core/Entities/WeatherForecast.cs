namespace DefaultProject.Domain.Entities;

public class WeatherForecast
{
    public Guid Id { get; set; }
    
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF { get; set; }

    public string? Summary { get; set; }

    public string FullName { get; private set; }

    public string FirstName { get; set; }
    
    public string LastName { get; set; }

    public string City { get; set; }
}