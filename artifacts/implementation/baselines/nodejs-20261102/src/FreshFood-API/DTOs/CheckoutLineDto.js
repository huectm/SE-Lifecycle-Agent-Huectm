/**
 * Design revision 2026-11-02: CheckoutLineDto
 * Ownership: FreshFood-API.DTOs
 * + ProductId: EntityId
 * + BatchId: EntityId
 * + Quantity: number
 * + UnitPrice: VndAmountString
 * + Discount: VndAmountString
 */
/** CheckoutLineDto — FreshFood-API.DTOs; approved design source: detailed-class-model.json. */
export class CheckoutLineDto {
  constructor(values = {}) {
    this.ProductId = values.ProductId;
    this.BatchId = values.BatchId;
    this.Quantity = values.Quantity;
    this.UnitPrice = values.UnitPrice;
    this.Discount = values.Discount;
  }
}
