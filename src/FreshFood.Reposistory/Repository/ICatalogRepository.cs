namespace FreshFood.Reposistory.Repository;

public interface ICatalogRepository
{
    Task<List<Product>> FindActiveAsync(string? keyword, int? categoryId, bool clearanceOnly, CancellationToken signal);
    Task<List<ProductCategory>> GetCategoriesAsync(CancellationToken signal);
    Task<Product?> GetProductAsync(string productId, CancellationToken signal);
    Task<List<BatchInventory>> GetSellableBatchesAsync(List<string> productIds, CancellationToken signal);
    Task<List<Product>> GetPopularAsync(int limit, CancellationToken signal);
}
