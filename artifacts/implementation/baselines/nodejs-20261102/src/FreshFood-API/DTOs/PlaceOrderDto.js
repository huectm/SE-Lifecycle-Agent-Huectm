/**
 * Design revision 2026-11-02: PlaceOrderDto
 * Ownership: FreshFood-API.DTOs
 * + AddressId: EntityId
 * + PaymentMethod: PaymentMethod
 * + CheckoutReference: string
 * + IdempotencyKey: string
 */
/** PlaceOrderDto — FreshFood-API.DTOs; approved design source: detailed-class-model.json. */
export class PlaceOrderDto {
  constructor(values = {}) {
    this.AddressId = values.AddressId;
    this.PaymentMethod = values.PaymentMethod;
    this.CheckoutReference = values.CheckoutReference;
    this.IdempotencyKey = values.IdempotencyKey;
  }
}
