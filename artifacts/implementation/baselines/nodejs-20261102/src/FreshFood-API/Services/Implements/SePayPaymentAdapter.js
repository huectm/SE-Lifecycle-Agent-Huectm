/**
 * Design revision 2026-11-02: SePayPaymentAdapter
 * Ownership: FreshFood-API.Services.Implements
 * - http: HttpTransport
 * + SePayPaymentAdapter(http: HttpTransport)
 * + CreateQrAsync(reference: string, amount: VndAmount, signal: AbortSignal): Promise<PaymentQrDto>
 * + VerifyNoticeAsync(notice: PaymentNoticeDto, signal: AbortSignal): Promise<VerifiedPaymentDto>
 */
export class SePayPaymentAdapter {constructor(transport){this.transport=transport;}async CreateQrAsync(reference,amount,signal){return this.transport.SendAsync('sepay:create-qr',{Reference:reference,Amount:amount.toString()},signal);}async VerifyNoticeAsync(notice,signal){return this.transport.SendAsync('sepay:verify-notice',notice,signal);} }
