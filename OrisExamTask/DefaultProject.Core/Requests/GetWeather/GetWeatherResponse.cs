namespace DefaultProject.Contracts.Requests.GetWeather;

public class GetWeatherResponse
{
    public GetWeatherResponse(List<GetWeatherResponseItem> entities, int totalCount)
    {
        Entities = entities;
        TotalCount = totalCount;
    }

    public List<GetWeatherResponseItem> Entities { get; set; }

    public int TotalCount { get; set; }
}