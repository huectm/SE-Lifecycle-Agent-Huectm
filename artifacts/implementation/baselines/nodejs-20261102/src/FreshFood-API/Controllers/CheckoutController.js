/**
 * Design revision 2026-11-02: CheckoutController
 * Ownership: FreshFood-API.Controllers
 * - service: ICheckoutService
 * + CheckoutController(service: ICheckoutService)
 * + PrepareCheckoutAsync(request: CheckoutInputDto, signal: AbortSignal): Promise<CheckoutSummaryDto>
 * + PlaceOrderAsync(request: PlaceOrderDto, signal: AbortSignal): Promise<OrderConfirmationDto>
 * + CreatePaymentQrAsync(request: PaymentQrRequestDto, signal: AbortSignal): Promise<PaymentQrDto>
 */
/** UC-C06: injected service contract; transport/authentication belongs to HTTP composition. */
export class CheckoutController {
  constructor(service) { this.service = service; }
  async PrepareCheckoutAsync(request, signal) { return this.service.PrepareCheckoutAsync(request, signal); }
  async PlaceOrderAsync(request, signal) { return this.service.PlaceOrderAsync(request, signal); }
  async CreatePaymentQrAsync(request, signal) { return this.service.CreatePaymentQrAsync(request, signal); }
}
