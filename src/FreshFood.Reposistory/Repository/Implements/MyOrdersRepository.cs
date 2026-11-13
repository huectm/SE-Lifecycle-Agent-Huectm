namespace FreshFood.Reposistory.Repository.Implements;

public sealed class MyOrdersRepository(IRepositorySession session) : SqlRepository(session), IMyOrdersRepository
{
    public Task<List<Order>> FindOwnedAsync(string customerId, CancellationToken signal) => LoadOrders(customerId, signal);
    public async Task<Order> LockOwnedAsync(string customerId, string orderId, CancellationToken signal)
    {
        RequireTransaction();
        if (await One<Order>("SELECT order_id FROM orders WHERE customer_id=$1 AND order_id=$2 FOR UPDATE", signal, Id(customerId), Id(orderId)) is null) throw new DomainException("NOT_FOUND", 404);
        return (await LoadOrders(customerId, signal)).Single(o => o.OrderId == orderId);
    }
    public Task<List<BatchInventory>> GetCurrentBatchesAsync(List<string> productIds, CancellationToken signal) => Batches(productIds, signal);
    public async Task SaveCartAsync(Cart cart, CancellationToken signal)
    {
        var current = await LoadCart(cart.CustomerId, null, signal);
        foreach (var item in cart.Items) current.ChangeQuantity(item.ProductId, item.Quantity);
        await SaveCart(current, signal);
    }
    public async Task<bool> SaveReviewOnceAsync(OrderReview review, CancellationToken signal) { RequireTransaction(); return (await Rows<OrderReview>("INSERT INTO order_reviews(order_id,customer_id,rating,comment) VALUES($1,$2,$3,$4) ON CONFLICT (order_id) DO NOTHING RETURNING review_id", signal, Id(review.OrderId), Id(review.CustomerId), review.Rating, review.Comment)).Count > 0; }
    public Task<ReturnReceipt?> GetReturnReceiptAsync(string orderId, CancellationToken signal) => One<ReturnReceipt>("SELECT * FROM return_receipts WHERE order_id=$1", signal, Id(orderId));
    public Task<Refund?> GetRefundAsync(string orderId, CancellationToken signal) => One<Refund>("SELECT * FROM refunds WHERE order_id=$1 ORDER BY refund_id DESC LIMIT 1", signal, Id(orderId));
}
