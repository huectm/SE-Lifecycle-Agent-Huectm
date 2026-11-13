/**
 * Design revision 2026-11-02: OrderListDto
 * Ownership: FreshFood-API.DTOs
 * + Orders: ReadonlyArray<OrderSummaryDto>
 */
/** OrderListDto — FreshFood-API.DTOs; approved design source: detailed-class-model.json. */
export class OrderListDto {
  constructor(values = {}) {
    this.Orders = values.Orders;
  }
}
