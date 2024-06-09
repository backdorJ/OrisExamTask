using DefaultProject.Contracts.Models;
using DefaultProject.Domain.Abstractions;

namespace DefaultProject.Domain.Requests.GetWeather;

public class GetWeatherRequest : IPaginationFilter
{
    private int _pageNumber;
    private int _pageSize;

    public GetWeatherRequest()
    {
        _pageNumber = PaginationDefaults.PageNumber;
        _pageSize = PaginationDefaults.PageSize;
    }

    public GetWeatherRequest(GetWeatherRequest request)
    {
        PageNumber = request.PageNumber;
        PageSize = request.PageSize;
    }
    
    public DateOnly? DateFrom { get; set; }

    public DateOnly? DateTo { get; set; }
    
    public string? City { get; set; }

    public int PageNumber
    {
        get => _pageNumber;
        set => _pageNumber = value > 0 ? value : PaginationDefaults.PageNumber;
    }

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > 0 ? value : PaginationDefaults.PageSize;
    }
}