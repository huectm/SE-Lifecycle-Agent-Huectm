namespace FreshFood.Reposistory.Repository;

public interface IMyOrdersRepository
{
    Task<List<Order>> FindOwnedAsync(string customerId, CancellationToken signal);
    Task<Order> LockOwnedAsync(string customerId, string orderId, CancellationToken signal);
    Task<List<BatchInventory>> GetCurrentBatchesAsync(List<string> productIds, CancellationToken signal);
    Task SaveCartAsync(Cart cart, CancellationToken signal);
    Task<bool> SaveReviewOnceAsync(OrderReview review, CancellationToken signal);
    Task<ReturnReceipt?> GetReturnReceiptAsync(string orderId, CancellationToken signal);
    Task<Refund?> GetRefundAsync(string orderId, CancellationToken signal);
}
