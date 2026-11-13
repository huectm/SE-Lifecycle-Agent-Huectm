using Microsoft.AspNetCore.Mvc;
namespace FreshFood.Api.Controllers;

[ApiController]
public sealed class PaymentWebhookController(PaymentNoticeHandler handler) : ControllerBase
{
    [HttpPost("/api/payments/sepay/webhook")]
    public async Task<PaymentResultDto> HandleAsync([ModelBinder(BinderType = typeof(PaymentNoticeModelBinder))] PaymentNoticeDto notice, CancellationToken signal)
    {
        return await handler.HandleAsync(notice, signal);
    }
}
