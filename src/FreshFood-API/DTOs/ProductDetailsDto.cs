namespace FreshFood.Api.DTOs;

public class ProductDetailsDto
{
    public ProductSummaryDto Product { get; set; } = default!;
    public string? Description { get; set; }
    public List<BatchOfferDto> AvailableBatches { get; set; } = [];
}
