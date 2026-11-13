namespace FreshFood.Api.DTOs;

public class CheckoutSummaryDto
{
    public string SubTotal { get; set; } = string.Empty;
    public string ShippingFee { get; set; } = string.Empty;
    public decimal DistanceKm { get; set; }
    public string Total { get; set; } = string.Empty;
    public List<CheckoutLineDto> Lines { get; set; } = [];
}
