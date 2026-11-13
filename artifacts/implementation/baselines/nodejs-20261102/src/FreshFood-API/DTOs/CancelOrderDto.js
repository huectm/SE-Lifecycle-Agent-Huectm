/**
 * Design revision 2026-11-02: CancelOrderDto
 * Ownership: FreshFood-API.DTOs
 * + OrderId: EntityId
 * + Reason: string
 */
/** CancelOrderDto — FreshFood-API.DTOs; approved design source: detailed-class-model.json. */
export class CancelOrderDto {
  constructor(values = {}) {
    this.OrderId = values.OrderId;
    this.Reason = values.Reason;
  }
}
