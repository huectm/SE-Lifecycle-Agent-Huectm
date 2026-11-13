namespace FreshFood.Reposistory.Entities;

public partial class ShippingFeeSettlement
{
    public string ShippingSettlementId { get; set; } = string.Empty;
    public string OrderId { get; set; } = string.Empty;
    public string DeliveryAgentId { get; set; } = string.Empty;
    public VndAmount CustomerFeeDue { get; set; } = default!;
    public string CollectionPaymentId { get; set; } = string.Empty;
    public VndAmount CompensationDueAmount { get; set; } = default!;
    public VndAmount CompensationPaidAmount { get; set; } = default!;
    public DateTimeOffset CompensatedAt { get; set; }
    public string SettlementReference { get; set; } = string.Empty;
}
