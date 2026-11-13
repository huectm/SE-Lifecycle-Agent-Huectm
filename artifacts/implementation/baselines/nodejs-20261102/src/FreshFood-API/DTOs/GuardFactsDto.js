/**
 * Design revision 2026-11-02: GuardFactsDto
 * Ownership: FreshFood-API.DTOs
 * + FirstOrder: boolean
 * + PhoneConfirmed: boolean
 * + VerifiedPayment: boolean
 * + CompleteReceipt: boolean
 * + ConfirmedCause: string?
 * + CapturedGoods: VndAmountString
 * + CapturedShipping: VndAmountString
 * + SettledRefund: VndAmountString
 */
/** GuardFactsDto — FreshFood-API.DTOs; approved design source: detailed-class-model.json. */
export class GuardFactsDto {
  constructor(values = {}) {
    this.FirstOrder = values.FirstOrder;
    this.PhoneConfirmed = values.PhoneConfirmed;
    this.VerifiedPayment = values.VerifiedPayment;
    this.CompleteReceipt = values.CompleteReceipt;
    this.ConfirmedCause = values.ConfirmedCause;
    this.CapturedGoods = values.CapturedGoods;
    this.CapturedShipping = values.CapturedShipping;
    this.SettledRefund = values.SettledRefund;
  }
}
