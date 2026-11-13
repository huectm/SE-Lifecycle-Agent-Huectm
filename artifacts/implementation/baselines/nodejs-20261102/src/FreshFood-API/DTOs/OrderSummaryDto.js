/**
 * Design revision 2026-11-02: OrderSummaryDto
 * Ownership: FreshFood-API.DTOs
 * + OrderId: EntityId
 * + OrderNumber: string
 * + OrderDate: IsoDateTime
 * + Status: OrderStatus
 * + Total: VndAmountString
 */
/** OrderSummaryDto — FreshFood-API.DTOs; approved design source: detailed-class-model.json. */
export class OrderSummaryDto {
  constructor(values = {}) {
    this.OrderId = values.OrderId;
    this.OrderNumber = values.OrderNumber;
    this.OrderDate = values.OrderDate;
    this.Status = values.Status;
    this.Total = values.Total;
  }
}
