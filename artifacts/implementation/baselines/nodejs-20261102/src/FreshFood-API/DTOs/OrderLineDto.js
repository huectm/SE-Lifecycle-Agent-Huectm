/**
 * Design revision 2026-11-02: OrderLineDto
 * Ownership: FreshFood-API.DTOs
 * + ProductName: string
 * + Quantity: number
 * + UnitPrice: VndAmountString
 * + LineTotal: VndAmountString
 */
/** OrderLineDto — FreshFood-API.DTOs; approved design source: detailed-class-model.json. */
export class OrderLineDto {
  constructor(values = {}) {
    this.ProductName = values.ProductName;
    this.Quantity = values.Quantity;
    this.UnitPrice = values.UnitPrice;
    this.LineTotal = values.LineTotal;
  }
}
