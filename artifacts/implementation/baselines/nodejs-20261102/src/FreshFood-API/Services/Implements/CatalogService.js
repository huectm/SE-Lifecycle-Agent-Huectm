/**
 * Design revision 2026-11-02: CatalogService
 * Ownership: FreshFood-API.Services.Implements
 * - catalogRepository: ICatalogRepository
 * - pricing: IBatchPricingPolicy
 * + CatalogService(catalogRepository: ICatalogRepository, pricing: IBatchPricingPolicy)
 * + GetCatalogAsync(query: CatalogQueryDto, signal: AbortSignal): Promise<CatalogResultDto>
 * + SearchAsync(query: CatalogQueryDto, signal: AbortSignal): Promise<CatalogResultDto>
 * + GetProductDetailsAsync(productId: EntityId, signal: AbortSignal): Promise<ProductDetailsDto>
 * + GetClearanceAsync(query: CatalogQueryDto, signal: AbortSignal): Promise<CatalogResultDto>
 */
import { checkSignal, owned, sellable, fefo, id } from './shared.js';
export class CatalogService {
  constructor(catalogRepository, pricing) { this.catalogRepository=catalogRepository; this.pricing=pricing; }
  async summaries(products, signal) {
    const now=new Date(); const batches=await this.catalogRepository.GetSellableBatchesAsync(products.map(p=>p.ProductId),signal);
    return products.filter(p=>p.IsActive).map(p=>{ const stock=fefo(batches.filter(b=>b.ProductId===p.ProductId && sellable(b,now))); return {ProductId:p.ProductId,Name:p.ProductName,Unit:p.UnitOfMeasure,AvailableQuantity:stock.reduce((s,b)=>s+b.CurrentStock-b.ReservedStock,0),CurrentPrice:stock.length?this.pricing.Quote(stock[0],now).toString():'0'}; });
  }
  async GetCatalogAsync(query={},signal) {
    checkSignal(signal); const products=await this.catalogRepository.FindActiveAsync(query.Keyword??null,query.CategoryId??null,query.ClearanceOnly===true,signal);
    return {Items:await this.summaries(products,signal),Categories:(await this.catalogRepository.GetCategoriesAsync(signal)).map(c=>({CategoryId:String(c.CategoryId),Name:c.CategoryName})),Alternatives:products.length?[]:await this.summaries(await this.catalogRepository.GetPopularAsync(6,signal),signal)};
  }
  async SearchAsync(query,signal) { return this.GetCatalogAsync(query,signal); }
  async GetClearanceAsync(query,signal) { return this.GetCatalogAsync({...query,ClearanceOnly:true},signal); }
  async GetProductDetailsAsync(productId,signal) {
    id(productId);const product=owned(await this.catalogRepository.GetProductAsync(productId,signal));owned(product.IsActive);
    const batches=await this.catalogRepository.GetSellableBatchesAsync([productId],signal);const now=new Date();
    return {Product:(await this.summaries([product],signal))[0],Description:product.Description,AvailableBatches:fefo(batches.filter(b=>sellable(b,now))).map(b=>({BatchId:b.BatchId,ExpiryDate:b.ExpiryDate,Price:this.pricing.Quote(b,now).toString(),Clearance:Number(b.DiscountRate)>0}))};
  }
}
