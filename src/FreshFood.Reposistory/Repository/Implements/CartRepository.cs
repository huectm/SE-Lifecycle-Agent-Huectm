namespace FreshFood.Reposistory.Repository.Implements;

public sealed class CartRepository(IRepositorySession session) : SqlRepository(session), ICartRepository
{
    public Task<Cart> GetAsync(string? customerId, string? sessionId, CancellationToken signal) => LoadCart(customerId, sessionId, signal);
    public Task<List<Product>> GetProductsAsync(List<string> ids, CancellationToken signal) => Rows<Product>("SELECT * FROM products WHERE product_id=ANY($1::bigint[])", signal, ids.Select(Id).ToArray());
    public Task<List<BatchInventory>> GetSellableBatchesAsync(List<string> ids, CancellationToken signal) => Batches(ids, signal);
    public Task SaveAsync(Cart cart, CancellationToken signal) => SaveCart(cart, signal);
}
