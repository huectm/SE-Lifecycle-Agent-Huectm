namespace FreshFood.Api.Services;

public interface ICheckoutService
{
    Task<CheckoutSummaryDto> PrepareCheckoutAsync(CheckoutInputDto request, CancellationToken signal);
    Task<OrderConfirmationDto> PlaceOrderAsync(PlaceOrderDto request, CancellationToken signal);
    Task<PaymentQrDto> CreatePaymentQrAsync(PaymentQrRequestDto request, CancellationToken signal);
    Task<PaymentResultDto> HandleVerifiedPaymentAsync(PaymentNoticeDto request, CancellationToken signal);
}
