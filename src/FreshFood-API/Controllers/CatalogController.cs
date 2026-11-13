using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace FreshFood.Api.Controllers;

[ApiController]
public sealed class CatalogController(ICatalogService service) : ControllerBase
{
    [HttpGet("/api/catalog")]
    public Task<CatalogResultDto> GetCatalogAsync([FromQuery] CatalogQueryDto query, CancellationToken signal)
    {
        return service.GetCatalogAsync(query, signal);
    }
    [HttpGet("/api/catalog/search")]
    public Task<CatalogResultDto> SearchAsync([FromQuery] CatalogQueryDto query, CancellationToken signal)
    {
        return service.SearchAsync(query, signal);
    }
    [HttpGet("/api/catalog/clearance")]
    public Task<CatalogResultDto> GetClearanceAsync([FromQuery] CatalogQueryDto query, CancellationToken signal)
    {
        return service.GetClearanceAsync(query, signal);
    }
    [HttpGet("/api/products/{productId}")]
    public Task<ProductDetailsDto> GetProductDetailsAsync(string productId, CancellationToken signal)
    {
        return service.GetProductDetailsAsync(productId, signal);
    }
}
