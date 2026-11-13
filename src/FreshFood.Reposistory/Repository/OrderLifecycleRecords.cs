namespace FreshFood.Reposistory.Repository;

public class OrderLifecycleRecords
{
    public Order Order { get; set; } = default!;
    public DeliveryFailure? Failure { get; set; }
    public ReturnReceipt? Receipt { get; set; }
    public Refund? Refund { get; set; }
    public List<OrderPayment> Payments { get; set; } = [];
}
