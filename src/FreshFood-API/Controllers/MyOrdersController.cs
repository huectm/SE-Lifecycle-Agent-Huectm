using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace FreshFood.Api.Controllers;

[ApiController]
[Authorize]
public sealed class MyOrdersController(IMyOrdersService service) : ControllerBase
{
    [HttpGet("/api/orders")]
    public Task<OrderListDto> GetOrdersAsync(CancellationToken signal)
    {
        return service.GetOrdersAsync(signal);
    }
    [HttpGet("/api/orders/{orderId}")]
    public Task<OrderDetailsDto> GetOrderDetailsAsync(string orderId, CancellationToken signal)
    {
        return service.GetOrderDetailsAsync(orderId, signal);
    }
    [HttpPost("/api/orders/{orderId}/cancel")]
    public Task<OperationResultDto> CancelOrderAsync(string orderId, [FromBody] CancelOrderDto request, CancellationToken signal)
    {
        request.OrderId = orderId;
        return service.CancelOrderAsync(request, signal);
    }
    [HttpPost("/api/orders/{orderId}/reorder")]
    public Task<CartResultDto> ReorderAsync(string orderId, CancellationToken signal)
    {
        return service.ReorderAsync(orderId, signal);
    }
    [HttpPost("/api/orders/{orderId}/review")]
    public Task<OperationResultDto> SubmitReviewAsync(string orderId, [FromBody] OrderReviewDto request, CancellationToken signal)
    {
        request.OrderId = orderId;
        return service.SubmitReviewAsync(request, signal);
    }
}
