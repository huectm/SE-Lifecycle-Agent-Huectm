/**
 * Design revision 2026-11-02: IPaymentGateway
 * Ownership: FreshFood-API.Services
 * + CreateQrAsync(reference: string, amount: VndAmount, signal: AbortSignal): Promise<PaymentQrDto>
 * + VerifyNoticeAsync(notice: PaymentNoticeDto, signal: AbortSignal): Promise<VerifiedPaymentDto>
 */
/** IPaymentGateway — FreshFood-API.Services; approved design source: detailed-class-model.json. */
export class IPaymentGateway {
  async CreateQrAsync(reference, amount, signal) { throw Object.assign(new Error("IPaymentGateway.CreateQrAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async VerifyNoticeAsync(notice, signal) { throw Object.assign(new Error("IPaymentGateway.VerifyNoticeAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
}
