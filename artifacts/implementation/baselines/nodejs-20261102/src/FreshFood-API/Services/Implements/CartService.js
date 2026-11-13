/**
 * Design revision 2026-11-02: CartService
 * Ownership: FreshFood-API.Services.Implements
 * - cartRepository: ICartRepository
 * - currentCustomer: ICurrentCustomer
 * - unitOfWork: IUnitOfWork
 * - pricing: IBatchPricingPolicy
 * + CartService(cartRepository: ICartRepository, currentCustomer: ICurrentCustomer, unitOfWork: IUnitOfWork, pricing: IBatchPricingPolicy)
 * + GetCartAsync(identity: CartIdentityDto, signal: AbortSignal): Promise<CartResultDto>
 * + ChangeQuantityAsync(request: CartChangeDto, signal: AbortSignal): Promise<CartResultDto>
 * + RemoveItemAsync(productId: EntityId, signal: AbortSignal): Promise<CartResultDto>
 */
import { checkSignal, quantity, id, requireValue, sellable, fefo } from './shared.js';
export class CartService {
  constructor(cartRepository,currentCustomer,unitOfWork,pricing) { Object.assign(this,{cartRepository,currentCustomer,unitOfWork,pricing}); }
  async load(signal) { const identity=this.currentCustomer.GetCartIdentity();return this.cartRepository.GetAsync(identity.CustomerId??null,identity.SessionId??null,signal); }
  async result(cart,signal) {
    const ids=cart.Items.map(i=>i.ProductId);const products=await this.cartRepository.GetProductsAsync(ids,signal);const batches=await this.cartRepository.GetSellableBatchesAsync(ids,signal);const now=new Date();let subtotal=0n;const warnings=[];
    const lines=cart.Items.map(i=>{ const p=products.find(p=>p.ProductId===i.ProductId);const stock=fefo(batches.filter(b=>b.ProductId===i.ProductId&&sellable(b,now)));const available=p?.IsActive?stock.reduce((s,b)=>s+b.CurrentStock-b.ReservedStock,0):0;const price=stock.length?BigInt(this.pricing.Quote(stock[0],now).ToWire()):0n;const line=price*BigInt(i.Quantity);subtotal+=line;if(i.Quantity>available)warnings.push('UNAVAILABLE:'+i.ProductId);return {ProductId:i.ProductId,Quantity:i.Quantity,AvailableQuantity:available,CurrentPrice:price.toString(),LineTotal:line.toString()}; });
    return {Lines:lines,SubTotal:subtotal.toString(),CanCheckout:lines.length>0&&!warnings.length,Warnings:warnings};
  }
  async GetCartAsync(_identity,signal) { checkSignal(signal);return this.result(await this.load(signal),signal); }
  async ChangeQuantityAsync(request,signal) {
    id(request.ProductId);quantity(request.Quantity);
    return this.unitOfWork.ExecuteAsync(async()=>{const cart=await this.load(signal);const products=await this.cartRepository.GetProductsAsync([request.ProductId],signal);requireValue(products.some(p=>p.IsActive),'PRODUCT_UNAVAILABLE',422);const batches=await this.cartRepository.GetSellableBatchesAsync([request.ProductId],signal);const available=batches.filter(b=>sellable(b)).reduce((s,b)=>s+b.CurrentStock-b.ReservedStock,0);requireValue(available>0,'OUT_OF_STOCK',422);
      const desired=request.Quantity;const actual=Math.min(desired,available);cart.ChangeQuantity(request.ProductId,actual);await this.cartRepository.SaveAsync(cart,signal);const result=await this.result(cart,signal);if(actual<desired)result.Warnings.push('QUANTITY_CLAMPED:'+request.ProductId);return result;},signal);
  }
  async RemoveItemAsync(productId,signal) { id(productId);return this.unitOfWork.ExecuteAsync(async()=>{const cart=await this.load(signal);cart.RemoveItem(productId);await this.cartRepository.SaveAsync(cart,signal);return this.result(cart,signal);},signal); }
}
