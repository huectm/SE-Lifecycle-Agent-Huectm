namespace FreshFood.Reposistory.Repository.Implements;

public sealed class CheckoutClaim
{
    public bool Replay { get; init; }
    public string? Response { get; init; }
}
public sealed class CheckoutRepository(IRepositorySession session, IFefoBatchSpecification fefo) : SqlRepository(session), ICheckoutRepository
{
    public Task<Cart> GetCheckoutCartAsync(string customerId, CancellationToken signal) => LoadCart(customerId, null, signal);
    public async Task<CustomerAddress> GetOwnedAddressAsync(string customerId, string addressId, CancellationToken signal) =>
        await One<CustomerAddress>("SELECT * FROM customer_addresses WHERE customer_id=$1 AND address_id=$2" + Lock, signal, Id(customerId), Id(addressId)) ?? throw new DomainException("NOT_FOUND", 404);
    public Task<List<BatchInventory>> LockFefoBatchesAsync(List<string> productIds, CancellationToken signal)
    { fefo.Criteria(DateTimeOffset.UtcNow); return Batches(productIds, signal, Session.Active); }
    public async Task SaveOrderAsync(Order order, CancellationToken signal)
    {
        RequireTransaction();
        await Rows<Customer>("SELECT customer_id FROM customers WHERE customer_id=$1 FOR UPDATE", signal, Id(order.CustomerId));
        order.IsFirstOrder = (await Rows<Order>("SELECT order_id FROM orders WHERE customer_id=$1 LIMIT 1", signal, Id(order.CustomerId))).Count == 0;
        order.PhoneConfirmationStatus = "NOT_CONTACTED";
        foreach (var line in order.Details)
            if ((await Rows<BatchInventory>("UPDATE batch_inventory SET reserved_stock=reserved_stock+$1 WHERE batch_id=$2 AND current_stock-reserved_stock >= $1 RETURNING batch_id", signal, line.Quantity, Id(line.BatchId))).Count != 1)
                throw new DomainException("INSUFFICIENT_STOCK", 409);
        var saved = await One<Order>("INSERT INTO orders(order_number,customer_id,delivery_address_id,order_date,sub_total,delivery_distance,shipping_fee,total_amount,payment_method,payment_status,order_status,is_first_order,phone_confirmation_status) VALUES($1,$2,$3,$4,$5,$6,$7,$8,$9,$10,$11,$12,$13) RETURNING order_id", signal,
            order.OrderNumber, Id(order.CustomerId), Id(order.DeliveryAddressId), order.OrderDate, order.SubTotal.Units, order.DeliveryDistance, order.ShippingFee.Units, order.TotalAmount.Units, Encode(order.PaymentMethod), Encode(order.PaymentStatus), Encode(order.OrderStatus), order.IsFirstOrder, order.PhoneConfirmationStatus);
        order.OrderId = saved!.OrderId;
        foreach (var line in order.Details) await Rows<OrderDetail>("INSERT INTO order_details(order_id,batch_id,quantity,unit_price,discount_amount,line_total) VALUES($1,$2,$3,$4,$5,$6)", signal, Id(order.OrderId), Id(line.BatchId), line.Quantity, line.UnitPrice.Units, line.DiscountAmount.Units, line.LineTotal.Units);
    }
    public Task<bool> SavePaymentOnceAsync(OrderPayment payment, CancellationToken signal) => Gap<bool>("PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED");
    public async Task ClearCartAsync(string cartId, CancellationToken signal) { RequireTransaction(); await Rows<CartItem>("DELETE FROM cart_items WHERE cart_id=$1", signal, Id(cartId)); }
    private sealed class ClaimRow
    {
        public string IdempotencyKey { get; set; } = "";
        public string RequestHash { get; set; } = "";
        public string CheckoutReference { get; set; } = "";
        public string? Response { get; set; }
    }
    public async Task<object> ClaimCheckoutAsync(string customerId, string reference, string key, string requestHash, CancellationToken signal)
    {
        RequireTransaction();
        var inserted = await Rows<ClaimRow>("INSERT INTO checkout_idempotency(customer_id,operation,idempotency_key,checkout_reference,request_hash) VALUES($1,'PlaceOrder',$2,$3,$4) ON CONFLICT DO NOTHING RETURNING idempotency_key", signal, Id(customerId), key, reference, requestHash);
        var saved = await One<ClaimRow>("SELECT * FROM checkout_idempotency WHERE customer_id=$1 AND operation='PlaceOrder' AND idempotency_key=$2 FOR UPDATE", signal, Id(customerId), key)
            ?? throw new DomainException("CHECKOUT_REFERENCE_REUSED", 409);
        if (saved.RequestHash != requestHash || saved.CheckoutReference != reference) throw new DomainException("IDEMPOTENCY_KEY_REUSED", 409);
        if (saved.Response is not null) return new CheckoutClaim { Replay = true, Response = saved.Response };
        if (inserted.Count == 0) throw new DomainException("INCOMPLETE_IDEMPOTENCY_RECORD", 503);
        return new CheckoutClaim();
    }
    public async Task CompleteCheckoutAsync(string customerId, string reference, string key, object response, CancellationToken signal)
    {
        RequireTransaction(); var json = JsonSerializer.SerializeToElement(response); var orderId = json.GetProperty("OrderId").GetString()!;
        var updated = await Rows<Order>("UPDATE checkout_idempotency SET order_id=$1,response=$2::jsonb,completed_at=CURRENT_TIMESTAMP WHERE customer_id=$3 AND operation='PlaceOrder' AND idempotency_key=$4 AND checkout_reference=$5 AND response IS NULL AND EXISTS(SELECT 1 FROM orders o WHERE o.order_id=$1 AND o.customer_id=$3) RETURNING order_id", signal, Id(orderId), json.GetRawText(), Id(customerId), key, reference);
        if (updated.Count != 1) throw new DomainException("IDEMPOTENCY_COMPLETION_CONFLICT", 409);
        await Rows<Order>("UPDATE order_transition_events SET order_id=$1 WHERE aggregate_key=$2 AND event_id=$3 AND order_id IS NULL", signal, Id(orderId), "checkout:" + customerId + ":" + reference, key);
    }
}
