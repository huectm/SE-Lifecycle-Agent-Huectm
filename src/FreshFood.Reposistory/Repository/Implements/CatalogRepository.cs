namespace FreshFood.Reposistory.Repository.Implements;

public sealed class CatalogRepository(IRepositorySession session) : SqlRepository(session), ICatalogRepository
{
    public Task<List<Product>> FindActiveAsync(string? keyword, int? categoryId, bool clearanceOnly, CancellationToken signal) =>
        Rows<Product>("SELECT p.* FROM products p WHERE p.is_active=TRUE AND ($1::text IS NULL OR p.product_name ILIKE '%' || $1 || '%') AND ($2::bigint IS NULL OR p.category_id=$2) AND ($3=FALSE OR EXISTS(SELECT 1 FROM batch_inventory b WHERE b.product_id=p.product_id AND b.discount_rate>0 AND b.sale_status IN ('ACTIVE','DISCOUNTED') AND b.expiry_date>=CURRENT_DATE AND b.current_stock>b.reserved_stock)) ORDER BY p.product_id", signal, keyword, categoryId, clearanceOnly);
    public Task<List<ProductCategory>> GetCategoriesAsync(CancellationToken signal) => Rows<ProductCategory>("SELECT * FROM product_categories WHERE is_active=TRUE ORDER BY category_id", signal);
    public Task<Product?> GetProductAsync(string productId, CancellationToken signal) => One<Product>("SELECT * FROM products WHERE product_id=$1", signal, Id(productId));
    public Task<List<BatchInventory>> GetSellableBatchesAsync(List<string> productIds, CancellationToken signal) => Batches(productIds, signal);
    public Task<List<Product>> GetPopularAsync(int limit, CancellationToken signal) => Rows<Product>("SELECT p.* FROM products p LEFT JOIN batch_inventory b ON b.product_id=p.product_id LEFT JOIN order_details d ON d.batch_id=b.batch_id WHERE p.is_active=TRUE GROUP BY p.product_id ORDER BY COALESCE(SUM(d.quantity),0) DESC,p.product_id LIMIT $1", signal, limit);
}
