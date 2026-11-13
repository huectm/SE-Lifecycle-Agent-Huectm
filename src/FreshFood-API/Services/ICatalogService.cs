namespace FreshFood.Api.Services;

public interface ICatalogService
{
    Task<CatalogResultDto> GetCatalogAsync(CatalogQueryDto query, CancellationToken signal);
    Task<CatalogResultDto> SearchAsync(CatalogQueryDto query, CancellationToken signal);
    Task<ProductDetailsDto> GetProductDetailsAsync(string productId, CancellationToken signal);
    Task<CatalogResultDto> GetClearanceAsync(CatalogQueryDto query, CancellationToken signal);
}
