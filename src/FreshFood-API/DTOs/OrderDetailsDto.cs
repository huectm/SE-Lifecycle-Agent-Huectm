namespace FreshFood.Api.DTOs;

public class OrderDetailsDto
{
    public OrderSummaryDto Order { get; set; } = default!;
    public AddressDto Address { get; set; } = default!;
    public PaymentStatus PaymentStatus { get; set; }
    public List<OrderLineDto> Lines { get; set; } = [];
    public ReturnSummaryDto? Return { get; set; }
}
