namespace FreshFood.Reposistory.Repository.Implements;

public sealed class OrderLifecycleRepository(IRepositorySession session) : SqlRepository(session), IOrderLifecycleRepository
{
    public async Task<Order> LockOrderAsync(string orderId, CancellationToken signal)
    { RequireTransaction(); return await One<Order>("SELECT * FROM orders WHERE order_id=$1 FOR UPDATE", signal, Id(orderId)) ?? throw new DomainException("NOT_FOUND", 404); }
    public Task<OrderLifecycleRecords> LoadLifecycleAsync(string orderId, CancellationToken signal) => Gap<OrderLifecycleRecords>("TRUSTED_STANDALONE_LIFECYCLE_SNAPSHOT_TBD");
    public async Task SaveAsync(Order order, CancellationToken signal)
    { RequireTransaction(); await Rows<Order>("UPDATE orders SET order_status=$1,payment_status=$2,cancellation_reason=$3 WHERE order_id=$4", signal, Encode(order.OrderStatus), Encode(order.PaymentStatus), order.CancellationReason, Id(order.OrderId)); }
    public async Task<bool> RecordEventOnceAsync(string aggregateId, string eventId, string transitionId, CancellationToken signal)
    {
        RequireTransaction();
        long? orderId = long.TryParse(aggregateId, out var n) && n > 0 ? n : null;
        return (await Rows<Order>("INSERT INTO order_transition_events(aggregate_key,event_id,transition_id,order_id) VALUES($1,$2,$3,$4) ON CONFLICT(aggregate_key,event_id,transition_id) DO NOTHING RETURNING transition_event_id", signal, aggregateId, eventId, transitionId, orderId)).Count == 1;
    }
    public Task SaveOrderLinesAsync(Order order, List<OrderDetail> lines, CancellationToken signal) => Gap("SHARED_ORDER_LINE_EFFECTS_REQUIRE_REVIEW");
    public Task<bool> SavePaymentOnceAsync(OrderPayment payment, CancellationToken signal) => Gap<bool>("PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED");
    public Task SaveFailureAsync(DeliveryFailure failure, CancellationToken signal) => Gap("STAFF_DELIVERY_FAILURE_NOT_IN_CUSTOMER_INCREMENT");
    public Task SaveReceiptAsync(ReturnReceipt receipt, List<ReturnReceiptItem> items, CancellationToken signal) => Gap("STAFF_RETURN_RECEIPT_NOT_IN_CUSTOMER_INCREMENT");
    public Task<bool> SaveRefundOnceAsync(Refund refund, CancellationToken signal) => Gap<bool>("REFUND_PROVIDER_AND_STORAGE_REVIEW_REQUIRED");
    public Task SaveShippingSettlementAsync(ShippingFeeSettlement settlement, CancellationToken signal) => Gap("SHIPPING_SETTLEMENT_NOT_IN_CUSTOMER_INCREMENT");
    public async Task<List<BatchInventory>> LockReservedBatchesAsync(string orderId, CancellationToken signal)
    {
        RequireTransaction();
        var batches = await Rows<BatchInventory>("SELECT DISTINCT b.* FROM batch_inventory b JOIN order_details d ON d.batch_id=b.batch_id WHERE d.order_id=$1 ORDER BY b.batch_id", signal, Id(orderId));
        var locked = new List<BatchInventory>();
        foreach (var batch in batches) locked.Add((await One<BatchInventory>("SELECT * FROM batch_inventory WHERE batch_id=$1 FOR UPDATE", signal, Id(batch.BatchId)))!);
        return locked;
    }
    public async Task SaveBatchesAsync(List<BatchInventory> batches, CancellationToken signal)
    { RequireTransaction(); foreach (var batch in batches) await Rows<BatchInventory>("UPDATE batch_inventory SET reserved_stock=$1 WHERE batch_id=$2", signal, batch.ReservedStock, Id(batch.BatchId)); }
    public async Task AppendAuditAsync(AuditLog audit, CancellationToken signal)
    {
        RequireTransaction();
        if (string.IsNullOrEmpty(audit.CustomerId)) throw new DomainException("AUDIT_ACTOR_REQUIRED", 403);
        var rows = await Rows<AuditLog>("INSERT INTO audit_logs(staff_id,customer_id,action_type,entity_name,record_identifier,old_values,new_values) SELECT NULL,$1,'UPDATE','orders',order_id::text,$2::jsonb,$3::jsonb FROM orders WHERE order_id=$4 AND customer_id=$1 RETURNING log_id", signal, Id(audit.CustomerId), audit.OldValues, audit.NewValues, Id(audit.RecordIdentifier));
        if (rows.Count != 1) throw new DomainException("AUDIT_ORDER_NOT_OWNED", 403);
    }
}
