/**
 * Design revision 2026-11-02: PaymentQrDto
 * Ownership: FreshFood-API.DTOs
 * + QrPayload: string
 * + ExpiresAt: IsoDateTime
 */
/** PaymentQrDto — FreshFood-API.DTOs; approved design source: detailed-class-model.json. */
export class PaymentQrDto {
  constructor(values = {}) {
    this.QrPayload = values.QrPayload;
    this.ExpiresAt = values.ExpiresAt;
  }
}
