namespace DefaultProject.Domain.Requests.EditWeather;

public class EditWeatherRequest
{
    public string? FirstName { get; set; }

    public string? SecondName { get; set; }

    public string? Summary { get; set; }

    public int? TemperatureC { get; set; }

    public DateOnly? Date { get; set; }

    public string? City { get; set; }
}