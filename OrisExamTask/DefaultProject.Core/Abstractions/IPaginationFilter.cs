namespace DefaultProject.Domain.Abstractions;

public interface IPaginationFilter
{
    public int PageNumber { get; set; }

    public int PageSize { get; set; }
}