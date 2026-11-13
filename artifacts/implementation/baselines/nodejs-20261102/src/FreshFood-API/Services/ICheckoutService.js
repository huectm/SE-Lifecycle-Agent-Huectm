/**
 * Design revision 2026-11-02: ICheckoutService
 * Ownership: FreshFood-API.Services
 * + PrepareCheckoutAsync(request: CheckoutInputDto, signal: AbortSignal): Promise<CheckoutSummaryDto>
 * + PlaceOrderAsync(request: PlaceOrderDto, signal: AbortSignal): Promise<OrderConfirmationDto>
 * + CreatePaymentQrAsync(request: PaymentQrRequestDto, signal: AbortSignal): Promise<PaymentQrDto>
 * + HandleVerifiedPaymentAsync(request: PaymentNoticeDto, signal: AbortSignal): Promise<PaymentResultDto>
 */
/** ICheckoutService — FreshFood-API.Services; approved design source: detailed-class-model.json. */
export class ICheckoutService {
  async PrepareCheckoutAsync(request, signal) { throw Object.assign(new Error("ICheckoutService.PrepareCheckoutAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async PlaceOrderAsync(request, signal) { throw Object.assign(new Error("ICheckoutService.PlaceOrderAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async CreatePaymentQrAsync(request, signal) { throw Object.assign(new Error("ICheckoutService.CreatePaymentQrAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async HandleVerifiedPaymentAsync(request, signal) { throw Object.assign(new Error("ICheckoutService.HandleVerifiedPaymentAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
}
