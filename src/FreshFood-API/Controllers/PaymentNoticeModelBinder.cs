using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FreshFood.Api.Controllers;

public sealed class PaymentNoticeModelBinder : IModelBinder
{
    public async Task BindModelAsync(ModelBindingContext bindingContext)
    {
        ArgumentNullException.ThrowIfNull(bindingContext);
        var request = bindingContext.HttpContext.Request;
        using var reader = new StreamReader(request.Body, leaveOpen: true);
        var raw = await reader.ReadToEndAsync(bindingContext.HttpContext.RequestAborted);
        bindingContext.Result = ModelBindingResult.Success(new PaymentNoticeDto
        {
            RawBody = raw,
            Signature = request.Headers.Authorization.ToString(),
            ProviderReference = request.Headers["X-Provider-Reference"].ToString()
        });
    }
}
