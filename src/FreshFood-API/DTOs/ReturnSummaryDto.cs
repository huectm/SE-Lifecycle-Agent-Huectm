namespace FreshFood.Api.DTOs;

public class ReturnSummaryDto
{
    public string? FailureReason { get; set; }
    public string? ReceiptStatus { get; set; }
    public string? RefundStatus { get; set; }
    public string GoodsRefunded { get; set; } = string.Empty;
    public string ShippingRefunded { get; set; } = string.Empty;
    public string? InventoryDisposition { get; set; }
}
