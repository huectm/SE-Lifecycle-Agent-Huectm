using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace FreshFood.Api.Controllers;

[ApiController]
[Authorize]
public sealed class CheckoutController(ICheckoutService service) : ControllerBase
{
    [HttpGet("/api/checkout")]
    public Task<CheckoutSummaryDto> PrepareCheckoutAsync([FromQuery] CheckoutInputDto request, CancellationToken signal)
    {
        return service.PrepareCheckoutAsync(request, signal);
    }
    [HttpPost("/api/orders")]
    public Task<OrderConfirmationDto> PlaceOrderAsync([FromBody] PlaceOrderDto request, CancellationToken signal)
    {
        return service.PlaceOrderAsync(request, signal);
    }
    [HttpPost("/api/checkout/payment-qr")]
    public Task<PaymentQrDto> CreatePaymentQrAsync([FromBody] PaymentQrRequestDto request, CancellationToken signal)
    {
        return service.CreatePaymentQrAsync(request, signal);
    }
}
