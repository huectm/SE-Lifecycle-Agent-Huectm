/**
 * Design revision 2026-11-02: ProductDetailsDto
 * Ownership: FreshFood-API.DTOs
 * + Product: ProductSummaryDto
 * + Description: string?
 * + AvailableBatches: ReadonlyArray<BatchOfferDto>
 */
/** ProductDetailsDto — FreshFood-API.DTOs; approved design source: detailed-class-model.json. */
export class ProductDetailsDto {
  constructor(values = {}) {
    this.Product = values.Product;
    this.Description = values.Description;
    this.AvailableBatches = values.AvailableBatches;
  }
}
