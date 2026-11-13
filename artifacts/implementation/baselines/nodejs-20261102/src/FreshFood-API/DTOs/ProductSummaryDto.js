/**
 * Design revision 2026-11-02: ProductSummaryDto
 * Ownership: FreshFood-API.DTOs
 * + ProductId: EntityId
 * + Name: string
 * + Unit: string
 * + AvailableQuantity: number
 * + CurrentPrice: VndAmountString
 */
/** ProductSummaryDto — FreshFood-API.DTOs; approved design source: detailed-class-model.json. */
export class ProductSummaryDto {
  constructor(values = {}) {
    this.ProductId = values.ProductId;
    this.Name = values.Name;
    this.Unit = values.Unit;
    this.AvailableQuantity = values.AvailableQuantity;
    this.CurrentPrice = values.CurrentPrice;
  }
}
