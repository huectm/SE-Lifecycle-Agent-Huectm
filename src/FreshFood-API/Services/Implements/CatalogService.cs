namespace FreshFood.Api.Services.Implements;

public sealed class CatalogService(ICatalogRepository catalogRepository, IBatchPricingPolicy pricing) : ICatalogService
{
    private async Task<List<ProductSummaryDto>> Summaries(List<Product> products, CancellationToken ct)
    {
        var batches = await catalogRepository.GetSellableBatchesAsync(products.Select(p => p.ProductId).ToList(), ct);
        return products.Where(p => p.IsActive).Select(p =>
        {
            var stock = ServiceRules.Fefo(batches.Where(b => b.ProductId == p.ProductId));
            return new ProductSummaryDto
            {
                ProductId = p.ProductId,
                Name = p.ProductName,
                Unit = p.UnitOfMeasure,
                AvailableQuantity = stock.Sum(b => b.CurrentStock - b.ReservedStock),
                CurrentPrice = stock.Count > 0 ? pricing.Quote(stock[0], DateTimeOffset.UtcNow).ToWire() : "0"
            };
        }).ToList();
    }
    public async Task<CatalogResultDto> GetCatalogAsync(CatalogQueryDto query, CancellationToken signal)
    {
        int? category = query.CategoryId is null ? null : int.Parse(ServiceRules.Id(query.CategoryId), CultureInfo.InvariantCulture);
        var products = await catalogRepository.FindActiveAsync(query.Keyword, category, query.ClearanceOnly ?? false, signal);
        return new()
        {
            Items = await Summaries(products, signal),
            Categories = (await catalogRepository.GetCategoriesAsync(signal)).Select(c => new CategoryDto { CategoryId = c.CategoryId.ToString(CultureInfo.InvariantCulture), Name = c.CategoryName }).ToList(),
            Alternatives = products.Count > 0 ? [] : await Summaries(await catalogRepository.GetPopularAsync(6, signal), signal)
        };
    }
    public Task<CatalogResultDto> SearchAsync(CatalogQueryDto query, CancellationToken signal) => GetCatalogAsync(query, signal);
    public Task<CatalogResultDto> GetClearanceAsync(CatalogQueryDto query, CancellationToken signal) => GetCatalogAsync(new() { Keyword = query.Keyword, CategoryId = query.CategoryId, ClearanceOnly = true }, signal);
    public async Task<ProductDetailsDto> GetProductDetailsAsync(string productId, CancellationToken signal)
    {
        var p = await catalogRepository.GetProductAsync(ServiceRules.Id(productId), signal);
        if (p is null || !p.IsActive) throw new DomainException("NOT_FOUND", 404);
        var batches = await catalogRepository.GetSellableBatchesAsync([productId], signal);
        return new() { Product = (await Summaries([p], signal))[0], Description = p.Description, AvailableBatches = ServiceRules.Fefo(batches).Select(b => new BatchOfferDto { BatchId = b.BatchId, ExpiryDate = b.ExpiryDate, Price = pricing.Quote(b, DateTimeOffset.UtcNow).ToWire(), Clearance = b.DiscountRate > 0 }).ToList() };
    }
}
