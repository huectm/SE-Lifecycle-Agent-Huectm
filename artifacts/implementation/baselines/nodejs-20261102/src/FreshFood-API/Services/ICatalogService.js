/**
 * Design revision 2026-11-02: ICatalogService
 * Ownership: FreshFood-API.Services
 * + GetCatalogAsync(query: CatalogQueryDto, signal: AbortSignal): Promise<CatalogResultDto>
 * + SearchAsync(query: CatalogQueryDto, signal: AbortSignal): Promise<CatalogResultDto>
 * + GetProductDetailsAsync(productId: EntityId, signal: AbortSignal): Promise<ProductDetailsDto>
 * + GetClearanceAsync(query: CatalogQueryDto, signal: AbortSignal): Promise<CatalogResultDto>
 */
/** ICatalogService — FreshFood-API.Services; approved design source: detailed-class-model.json. */
export class ICatalogService {
  async GetCatalogAsync(query, signal) { throw Object.assign(new Error("ICatalogService.GetCatalogAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async SearchAsync(query, signal) { throw Object.assign(new Error("ICatalogService.SearchAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async GetProductDetailsAsync(productId, signal) { throw Object.assign(new Error("ICatalogService.GetProductDetailsAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async GetClearanceAsync(query, signal) { throw Object.assign(new Error("ICatalogService.GetClearanceAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
}
