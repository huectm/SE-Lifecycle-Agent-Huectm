namespace FreshFood.Reposistory.Entities;

public partial class BatchInventory
{
    public void Reserve(int quantity)
    {
        if (quantity <= 0 || CurrentStock - ReservedStock < quantity) throw new DomainException("INSUFFICIENT_STOCK", 409);
        ReservedStock = checked(ReservedStock + quantity);
    }
    public void ReleaseReservation(int quantity)
    {
        if (quantity <= 0 || ReservedStock < quantity) throw new DomainException("RESERVATION_INCONSISTENT", 409);
        ReservedStock -= quantity;
    }
}
public partial class Cart
{
    public void ChangeQuantity(string productId, int quantity)
    {
        if (quantity <= 0) throw new DomainException("INVALID_QUANTITY");
        var item = Items.SingleOrDefault(i => i.ProductId == productId);
        if (item is null) Items.Add(new CartItem { ProductId = productId, Quantity = quantity });
        else item.Quantity = quantity;
    }
    public void RemoveItem(string productId) => Items.RemoveAll(i => i.ProductId == productId);
}
public partial class Order
{
    public void ApplyFulfillment(OrderStatus expected, OrderStatus target)
    {
        if (OrderStatus != expected) throw new DomainException("STATE_CONFLICT", 409);
        OrderStatus = target;
    }
    public void RecordPayment(PaymentStatus expected, PaymentStatus target)
    {
        if (PaymentStatus != expected) throw new DomainException("STATE_CONFLICT", 409);
        PaymentStatus = target;
    }
    public void Cancel(OrderStatus expected, string reason)
    {
        if (string.IsNullOrWhiteSpace(reason)) throw new DomainException("CANCELLATION_REASON_REQUIRED");
        ApplyFulfillment(expected, OrderStatus.Cancelled);
        CancellationReason = reason;
    }
}
public partial class OrderDetail
{
    // Read projection through BatchInventory/Product; not additional database columns.
    public string ProductId { get; set; } = "";
    public string ProductName { get; set; } = "";
}
public sealed class BatchPricingPolicy : IBatchPricingPolicy
{
    public VndAmount Quote(BatchInventory batch, DateTimeOffset asOf)
    {
        var rate = batch.DiscountRate;
        if (rate != 0 && (rate < 10 || rate > 50 || decimal.Round(rate, 2) != rate)) throw new DomainException("INVALID_DISCOUNT");
        var amount = batch.RetailPrice.Units * (100 - rate) / 100;
        if (decimal.Truncate(amount) != amount) throw new DomainException("ROUNDING_POLICY_TBD", 503);
        return new(amount);
    }
}
public sealed class DeliveryFeePolicy : IDeliveryFeePolicy
{
    public VndAmount Quote(decimal distanceKm) => distanceKm switch
    {
        < 0 or > 10 => throw new DomainException("OUTSIDE_DELIVERY_AREA", 422),
        < 1 => new(10000),
        < 3 => new(20000),
        _ => new(30000)
    };
}
public sealed class FefoBatchSpecification : IFefoBatchSpecification
{
    public BatchCriteria Criteria(DateTimeOffset asOf) => new() { ActiveProductsOnly = true, AsOf = asOf, MinimumAvailable = 1, SortKeys = ["expiry_date", "batch_id"], LockForUpdate = true };
}
