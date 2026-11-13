/**
 * Design revision 2026-11-02: PaymentNoticeDto
 * Ownership: FreshFood-API.DTOs
 * + RawBody: string
 * + Signature: string
 * + ProviderReference: string
 */
/** PaymentNoticeDto — FreshFood-API.DTOs; approved design source: detailed-class-model.json. */
export class PaymentNoticeDto {
  constructor(values = {}) {
    this.RawBody = values.RawBody;
    this.Signature = values.Signature;
    this.ProviderReference = values.ProviderReference;
  }
}
