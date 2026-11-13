/**
 * Design revision 2026-11-02: PaymentResultDto
 * Ownership: FreshFood-API.DTOs
 * + Accepted: boolean
 * + Duplicate: boolean
 * + PaymentStatus: PaymentStatus
 */
/** PaymentResultDto — FreshFood-API.DTOs; approved design source: detailed-class-model.json. */
export class PaymentResultDto {
  constructor(values = {}) {
    this.Accepted = values.Accepted;
    this.Duplicate = values.Duplicate;
    this.PaymentStatus = values.PaymentStatus;
  }
}
