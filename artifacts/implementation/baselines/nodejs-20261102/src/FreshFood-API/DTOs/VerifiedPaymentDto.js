/**
 * Design revision 2026-11-02: VerifiedPaymentDto
 * Ownership: FreshFood-API.DTOs
 * + ProviderReference: string
 * + CheckoutReference: string
 * + GoodsAmount: VndAmountString
 * + ShippingAmount: VndAmountString
 * + VerifiedAt: IsoDateTime
 */
/** VerifiedPaymentDto — FreshFood-API.DTOs; approved design source: detailed-class-model.json. */
export class VerifiedPaymentDto {
  constructor(values = {}) {
    this.ProviderReference = values.ProviderReference;
    this.CheckoutReference = values.CheckoutReference;
    this.GoodsAmount = values.GoodsAmount;
    this.ShippingAmount = values.ShippingAmount;
    this.VerifiedAt = values.VerifiedAt;
  }
}
