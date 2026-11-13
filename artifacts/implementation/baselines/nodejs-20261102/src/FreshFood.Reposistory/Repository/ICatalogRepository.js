/**
 * Design revision 2026-11-02: ICatalogRepository
 * Ownership: FreshFood.Reposistory.Repository
 * + FindActiveAsync(keyword: string?, categoryId: number?, clearanceOnly: boolean, signal: AbortSignal): Promise<ReadonlyArray<Product>>
 * + GetCategoriesAsync(signal: AbortSignal): Promise<ReadonlyArray<ProductCategory>>
 * + GetProductAsync(productId: EntityId, signal: AbortSignal): Promise<Product?>
 * + GetSellableBatchesAsync(productIds: ReadonlyArray<EntityId>, signal: AbortSignal): Promise<ReadonlyArray<BatchInventory>>
 * + GetPopularAsync(limit: number, signal: AbortSignal): Promise<ReadonlyArray<Product>>
 */
/** ICatalogRepository — FreshFood.Reposistory.Repository; approved design source: detailed-class-model.json. */
export class ICatalogRepository {
  async FindActiveAsync(keyword, categoryId, clearanceOnly, signal) { throw Object.assign(new Error("ICatalogRepository.FindActiveAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async GetCategoriesAsync(signal) { throw Object.assign(new Error("ICatalogRepository.GetCategoriesAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async GetProductAsync(productId, signal) { throw Object.assign(new Error("ICatalogRepository.GetProductAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async GetSellableBatchesAsync(productIds, signal) { throw Object.assign(new Error("ICatalogRepository.GetSellableBatchesAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async GetPopularAsync(limit, signal) { throw Object.assign(new Error("ICatalogRepository.GetPopularAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
}
