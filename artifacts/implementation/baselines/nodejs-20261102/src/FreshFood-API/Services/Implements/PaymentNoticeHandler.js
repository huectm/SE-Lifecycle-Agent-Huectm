/**
 * Design revision 2026-11-02: PaymentNoticeHandler
 * Ownership: FreshFood-API.Services.Implements
 * - checkout: ICheckoutService
 * - payment: IPaymentGateway
 * + PaymentNoticeHandler(checkout: ICheckoutService, payment: IPaymentGateway)
 * + HandleAsync(notice: PaymentNoticeDto, signal: AbortSignal): Promise<PaymentResultDto>
 */
export class PaymentNoticeHandler {
  constructor(checkout,payment) {Object.assign(this,{checkout,payment});}
  async HandleAsync(notice,signal) { await this.payment.VerifyNoticeAsync(notice,signal);return this.checkout.HandleVerifiedPaymentAsync(notice,signal); }
}
