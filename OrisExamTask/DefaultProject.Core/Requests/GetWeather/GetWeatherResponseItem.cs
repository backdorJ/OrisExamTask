namespace DefaultProject.Contracts.Requests.GetWeather;

public class GetWeatherResponseItem
{
    public string? City { get; set; }

    public string? Summary { get; set; }

    public int? TemperatureC { get; set; }
    
    public int? TemperatureF { get; set; }
    
    public DateOnly? Date { get; set; }
}