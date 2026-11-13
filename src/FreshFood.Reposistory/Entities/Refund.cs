namespace FreshFood.Reposistory.Entities;

public partial class Refund
{
    public string RefundId { get; set; } = string.Empty;
    public string OrderId { get; set; } = string.Empty;
    public string ReturnReceiptId { get; set; } = string.Empty;
    public VndAmount GoodsAmount { get; set; } = default!;
    public VndAmount ShippingAmount { get; set; } = default!;
    public string RefundStatus { get; set; } = string.Empty;
    public string IdempotencyKey { get; set; } = string.Empty;
    public DateTimeOffset RequestedAt { get; set; }
    public DateTimeOffset SettledAt { get; set; }
    public string ProviderRefundReference { get; set; } = string.Empty;
}
