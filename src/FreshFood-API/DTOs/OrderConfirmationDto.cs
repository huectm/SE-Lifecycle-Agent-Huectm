namespace FreshFood.Api.DTOs;

public class OrderConfirmationDto
{
    public string OrderId { get; set; } = string.Empty;
    public string OrderNumber { get; set; } = string.Empty;
    public OrderStatus Status { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public string Total { get; set; } = string.Empty;
}
