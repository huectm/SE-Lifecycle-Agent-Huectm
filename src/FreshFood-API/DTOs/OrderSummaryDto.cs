namespace FreshFood.Api.DTOs;

public class OrderSummaryDto
{
    public string OrderId { get; set; } = string.Empty;
    public string OrderNumber { get; set; } = string.Empty;
    public DateTimeOffset OrderDate { get; set; }
    public OrderStatus Status { get; set; }
    public string Total { get; set; } = string.Empty;
}
