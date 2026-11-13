namespace FreshFood.Api.Services.Implements;

public sealed class MyOrdersService(IMyOrdersRepository myOrdersRepository, ICurrentCustomer currentCustomer, IUnitOfWork unitOfWork,
    INotificationGateway notificationGateway, IOrderStateMachine orderStateMachine, IBatchPricingPolicy pricing, ILogger<MyOrdersService> logger) : IMyOrdersService
{
    public async Task<OrderListDto> GetOrdersAsync(CancellationToken signal) => new() { Orders = (await myOrdersRepository.FindOwnedAsync(currentCustomer.RequireCustomerId(), signal)).Select(ServiceRules.Summary).ToList() };
    public async Task<OrderDetailsDto> GetOrderDetailsAsync(string orderId, CancellationToken signal)
    {
        ServiceRules.Id(orderId); var customer = currentCustomer.RequireCustomerId();
        var order = (await myOrdersRepository.FindOwnedAsync(customer, signal)).SingleOrDefault(o => o.OrderId == orderId) ?? throw new DomainException("NOT_FOUND", 404);
        var receipt = await myOrdersRepository.GetReturnReceiptAsync(orderId, signal); var refund = await myOrdersRepository.GetRefundAsync(orderId, signal);
        return new()
        {
            Order = ServiceRules.Summary(order),
            Address = ServiceRules.Address(order.DeliveryAddress),
            PaymentStatus = order.PaymentStatus,
            Lines = order.Details.Select(l => new OrderLineDto { ProductName = l.ProductName, Quantity = l.Quantity, UnitPrice = l.UnitPrice.ToWire(), LineTotal = l.LineTotal.ToWire() }).ToList(),
            Return = receipt is null && refund is null ? null : new()
            {
                FailureReason = order.Failure?.Reason,
                ReceiptStatus = receipt?.ReceiptStatus,
                RefundStatus = refund?.RefundStatus,
                GoodsRefunded = refund?.GoodsAmount.ToWire() ?? "0",
                ShippingRefunded = refund?.ShippingAmount.ToWire() ?? "0",
                InventoryDisposition = null
            }
        };
    }
    public async Task<OperationResultDto> CancelOrderAsync(CancelOrderDto request, CancellationToken signal)
    {
        var customer = currentCustomer.RequireCustomerId(); ServiceRules.Id(request.OrderId); var reason = ServiceRules.Text(request.Reason, "CANCELLATION_REASON_REQUIRED");
        var applied = await unitOfWork.ExecuteAsync(async ct =>
        {
            var order = await myOrdersRepository.LockOwnedAsync(customer, request.OrderId, ct);
            if (order.OrderStatus == OrderStatus.Cancelled) return false;
            try { return (await orderStateMachine.ProcessEventAsync(new(order.OrderId, customer, order), new() { Event = "cancelOrder", AggregateId = order.OrderId, EventId = "cancel:" + order.OrderId, Reason = reason }, ct)).Applied; }
            catch (DomainException e) when (e.Code is "STATE_EVENT_NOT_ALLOWED" or "STATE_GUARD_REJECTED") { throw new DomainException("CANCELLATION_NOT_ALLOWED", 409); }
        }, signal);
        if (applied)
            try { await notificationGateway.PublishAsync(new() { OrderId = request.OrderId, EventCode = "ORDER_CANCELLED" }, signal); }
            catch (Exception e) { logger.LogWarning(e, "Notification failed after committed cancellation {OrderId}", request.OrderId); }
        return new() { Success = true, MessageCode = applied ? "ORDER_CANCELLED" : "ORDER_ALREADY_CANCELLED" };
    }
    public Task<CartResultDto> ReorderAsync(string orderId, CancellationToken signal)
    {
        var customer = currentCustomer.RequireCustomerId(); ServiceRules.Id(orderId);
        return unitOfWork.ExecuteAsync(async ct =>
        {
            var order = await myOrdersRepository.LockOwnedAsync(customer, orderId, ct);
            var all = await myOrdersRepository.GetCurrentBatchesAsync(order.Details.Select(l => l.ProductId).Distinct().ToList(), ct);
            var result = new CartResultDto(); decimal total = 0;
            foreach (var group in order.Details.GroupBy(l => l.ProductId))
            {
                var stock = ServiceRules.Fefo(all.Where(b => b.ProductId == group.Key)); var available = stock.Sum(b => b.CurrentStock - b.ReservedStock);
                if (available == 0) { result.Warnings.Add("UNAVAILABLE:" + group.Key); continue; }
                var wanted = group.Sum(l => l.Quantity); var qty = Math.Min(wanted, available); var price = pricing.Quote(stock[0], DateTimeOffset.UtcNow).Units; total += price * qty;
                result.Lines.Add(new() { ProductId = group.Key, Quantity = qty, AvailableQuantity = available, CurrentPrice = ServiceRules.Money(price), LineTotal = ServiceRules.Money(price * qty) });
                if (qty < wanted) result.Warnings.Add("QUANTITY_CLAMPED:" + group.Key);
            }
            await myOrdersRepository.SaveCartAsync(new() { CustomerId = customer, Items = result.Lines.Select(l => new CartItem { ProductId = l.ProductId, Quantity = l.Quantity }).ToList() }, ct);
            result.SubTotal = ServiceRules.Money(total); result.CanCheckout = result.Lines.Count > 0; return result;
        }, signal);
    }
    public Task<OperationResultDto> SubmitReviewAsync(OrderReviewDto request, CancellationToken signal)
    {
        var customer = currentCustomer.RequireCustomerId(); ServiceRules.Id(request.OrderId); ServiceRules.Require(request.Rating is >= 1 and <= 5, "RATING_OUT_OF_RANGE");
        return unitOfWork.ExecuteAsync(async ct =>
        {
            var order = await myOrdersRepository.LockOwnedAsync(customer, request.OrderId, ct);
            ServiceRules.Require(order.OrderStatus == OrderStatus.Delivered, "REVIEW_REQUIRES_DELIVERED", 409);
            ServiceRules.Require(await myOrdersRepository.SaveReviewOnceAsync(new() { OrderId = request.OrderId, CustomerId = customer, Rating = request.Rating, Comment = request.Comment ?? "" }, ct), "REVIEW_ALREADY_EXISTS", 409);
            return new OperationResultDto { Success = true, MessageCode = "REVIEW_SAVED" };
        }, signal);
    }
}
