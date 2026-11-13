namespace FreshFood.Api.DTOs;

public class CatalogResultDto
{
    public List<ProductSummaryDto> Items { get; set; } = [];
    public List<CategoryDto> Categories { get; set; } = [];
    public List<ProductSummaryDto> Alternatives { get; set; } = [];
}
