namespace FreshFood.Api.DTOs;

public class CatalogQueryDto
{
    public string? Keyword { get; set; }
    public string? CategoryId { get; set; }
    public bool? ClearanceOnly { get; set; }
}
