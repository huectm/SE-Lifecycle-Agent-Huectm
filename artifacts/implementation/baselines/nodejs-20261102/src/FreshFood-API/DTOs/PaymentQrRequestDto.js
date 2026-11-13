/**
 * Design revision 2026-11-02: PaymentQrRequestDto
 * Ownership: FreshFood-API.DTOs
 * + CheckoutReference: string
 */
/** PaymentQrRequestDto — FreshFood-API.DTOs; approved design source: detailed-class-model.json. */
export class PaymentQrRequestDto {
  constructor(values = {}) {
    this.CheckoutReference = values.CheckoutReference;
  }
}
