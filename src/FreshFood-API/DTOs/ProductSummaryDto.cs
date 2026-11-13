namespace FreshFood.Api.DTOs;

public class ProductSummaryDto
{
    public string ProductId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Unit { get; set; } = string.Empty;
    public int AvailableQuantity { get; set; }
    public string CurrentPrice { get; set; } = string.Empty;
}
