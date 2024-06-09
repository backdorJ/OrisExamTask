namespace DefaultProject.Domain.Requests.AddWeather;

public class AddWeatherRequest
{
    public string City { get; set; } = default!;

    public DateOnly Date { get; set; } = default!;

    public int TemperatureC { get; set; }

    public string? Summary { get; set; }

    public string FirstName { get; set; } = default!;

    public string SecondName { get; set; } = default!;
}