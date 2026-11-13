namespace FreshFood.Reposistory.Entities;

public partial class OrderPayment
{
    public string PaymentId { get; set; } = string.Empty;
    public string OrderId { get; set; } = string.Empty;
    public string PaymentChannel { get; set; } = string.Empty;
    public string ProviderTransactionId { get; set; } = string.Empty;
    public VndAmount GoodsAmount { get; set; } = default!;
    public VndAmount ShippingAmount { get; set; } = default!;
    public VndAmount UnallocatedAmount { get; set; } = default!;
    public VndAmount CapturedAmount { get; set; } = default!;
    public DateTimeOffset ReceivedAt { get; set; }
    public int RecordedByStaffId { get; set; }
    public string CollectedByDeliveryAgentId { get; set; } = string.Empty;
}
