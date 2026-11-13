/**
 * Design revision 2026-11-02: OrderDetailsDto
 * Ownership: FreshFood-API.DTOs
 * + Order: OrderSummaryDto
 * + Address: AddressDto
 * + PaymentStatus: PaymentStatus
 * + Lines: ReadonlyArray<OrderLineDto>
 * + Return: ReturnSummaryDto?
 */
/** OrderDetailsDto — FreshFood-API.DTOs; approved design source: detailed-class-model.json. */
export class OrderDetailsDto {
  constructor(values = {}) {
    this.Order = values.Order;
    this.Address = values.Address;
    this.PaymentStatus = values.PaymentStatus;
    this.Lines = values.Lines;
    this.Return = values.Return;
  }
}
