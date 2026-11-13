namespace FreshFood.Api.DTOs;

public class OrderStateSnapshot
{
    public OrderStatus? FulfillmentState { get; set; }
    public PaymentStatus? PaymentState { get; set; }
    public string? RefundState { get; set; }
    public string? WorkflowNode { get; set; }
    public bool FulfillmentCompleted { get; set; }
}
