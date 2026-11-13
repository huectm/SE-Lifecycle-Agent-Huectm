/**
 * Design revision 2026-11-02: CartChangeDto
 * Ownership: FreshFood-API.DTOs
 * + ProductId: EntityId
 * + Quantity: number
 */
/** CartChangeDto — FreshFood-API.DTOs; approved design source: detailed-class-model.json. */
export class CartChangeDto {
  constructor(values = {}) {
    this.ProductId = values.ProductId;
    this.Quantity = values.Quantity;
  }
}
