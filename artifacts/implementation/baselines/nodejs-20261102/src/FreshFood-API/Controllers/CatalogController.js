/**
 * Design revision 2026-11-02: CatalogController
 * Ownership: FreshFood-API.Controllers
 * - service: ICatalogService
 * + CatalogController(service: ICatalogService)
 * + GetCatalogAsync(query: CatalogQueryDto, signal: AbortSignal): Promise<CatalogResultDto>
 * + SearchAsync(query: CatalogQueryDto, signal: AbortSignal): Promise<CatalogResultDto>
 * + GetProductDetailsAsync(productId: EntityId, signal: AbortSignal): Promise<ProductDetailsDto>
 * + GetClearanceAsync(query: CatalogQueryDto, signal: AbortSignal): Promise<CatalogResultDto>
 */
/** UC-C01: injected service contract; transport/authentication belongs to HTTP composition. */
export class CatalogController {
  constructor(service) { this.service = service; }
  async GetCatalogAsync(query, signal) { return this.service.GetCatalogAsync(query, signal); }
  async SearchAsync(query, signal) { return this.service.SearchAsync(query, signal); }
  async GetProductDetailsAsync(productId, signal) { return this.service.GetProductDetailsAsync(productId, signal); }
  async GetClearanceAsync(query, signal) { return this.service.GetClearanceAsync(query, signal); }
}
