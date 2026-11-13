/**
 * Design revision 2026-11-02: OrderConfirmationDto
 * Ownership: FreshFood-API.DTOs
 * + OrderId: EntityId
 * + OrderNumber: string
 * + Status: OrderStatus
 * + PaymentStatus: PaymentStatus
 * + Total: VndAmountString
 */
/** OrderConfirmationDto — FreshFood-API.DTOs; approved design source: detailed-class-model.json. */
export class OrderConfirmationDto {
  constructor(values = {}) {
    this.OrderId = values.OrderId;
    this.OrderNumber = values.OrderNumber;
    this.Status = values.Status;
    this.PaymentStatus = values.PaymentStatus;
    this.Total = values.Total;
  }
}
