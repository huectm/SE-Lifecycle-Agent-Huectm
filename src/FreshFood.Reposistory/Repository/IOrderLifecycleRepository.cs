namespace FreshFood.Reposistory.Repository;

public interface IOrderLifecycleRepository
{
    Task<Order> LockOrderAsync(string orderId, CancellationToken signal);
    Task<OrderLifecycleRecords> LoadLifecycleAsync(string orderId, CancellationToken signal);
    Task SaveAsync(Order order, CancellationToken signal);
    Task<bool> RecordEventOnceAsync(string aggregateId, string eventId, string transitionId, CancellationToken signal);
    Task SaveOrderLinesAsync(Order order, List<OrderDetail> lines, CancellationToken signal);
    Task<bool> SavePaymentOnceAsync(OrderPayment payment, CancellationToken signal);
    Task SaveFailureAsync(DeliveryFailure failure, CancellationToken signal);
    Task SaveReceiptAsync(ReturnReceipt receipt, List<ReturnReceiptItem> items, CancellationToken signal);
    Task<bool> SaveRefundOnceAsync(Refund refund, CancellationToken signal);
    Task SaveShippingSettlementAsync(ShippingFeeSettlement settlement, CancellationToken signal);
    Task<List<BatchInventory>> LockReservedBatchesAsync(string orderId, CancellationToken signal);
    Task SaveBatchesAsync(List<BatchInventory> batches, CancellationToken signal);
    Task AppendAuditAsync(AuditLog audit, CancellationToken signal);
}
