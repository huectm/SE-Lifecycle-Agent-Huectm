namespace FreshFood.Reposistory.Repository;

public interface ICartRepository
{
    Task<Cart> GetAsync(string? customerId, string? sessionId, CancellationToken signal);
    Task<List<Product>> GetProductsAsync(List<string> ids, CancellationToken signal);
    Task<List<BatchInventory>> GetSellableBatchesAsync(List<string> ids, CancellationToken signal);
    Task SaveAsync(Cart cart, CancellationToken signal);
}
