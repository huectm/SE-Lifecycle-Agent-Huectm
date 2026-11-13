/**
 * Design revision 2026-11-02: CartLineDto
 * Ownership: FreshFood-API.DTOs
 * + ProductId: EntityId
 * + Quantity: number
 * + AvailableQuantity: number
 * + CurrentPrice: VndAmountString
 * + LineTotal: VndAmountString
 */
/** CartLineDto — FreshFood-API.DTOs; approved design source: detailed-class-model.json. */
export class CartLineDto {
  constructor(values = {}) {
    this.ProductId = values.ProductId;
    this.Quantity = values.Quantity;
    this.AvailableQuantity = values.AvailableQuantity;
    this.CurrentPrice = values.CurrentPrice;
    this.LineTotal = values.LineTotal;
  }
}
