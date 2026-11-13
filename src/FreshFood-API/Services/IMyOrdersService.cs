namespace FreshFood.Api.Services;

public interface IMyOrdersService
{
    Task<OrderListDto> GetOrdersAsync(CancellationToken signal);
    Task<OrderDetailsDto> GetOrderDetailsAsync(string orderId, CancellationToken signal);
    Task<OperationResultDto> CancelOrderAsync(CancelOrderDto request, CancellationToken signal);
    Task<CartResultDto> ReorderAsync(string orderId, CancellationToken signal);
    Task<OperationResultDto> SubmitReviewAsync(OrderReviewDto request, CancellationToken signal);
}
