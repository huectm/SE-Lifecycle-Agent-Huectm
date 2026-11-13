using System.Security.Cryptography;
using System.Text;

namespace FreshFood.Api.Services.Implements;

public sealed class CheckoutService(ICheckoutRepository checkoutRepository, ICurrentCustomer currentCustomer, IUnitOfWork unitOfWork,
    IDistanceCalculator distanceCalculator, IPaymentGateway paymentGateway, INotificationGateway notificationGateway,
    IOrderStateMachine orderStateMachine, IBatchPricingPolicy pricing, IDeliveryFeePolicy deliveryFeePolicy, ILogger<CheckoutService> logger) : ICheckoutService
{
    private sealed record Preparation(string CustomerId, Cart Cart, CustomerAddress Address, decimal Distance, VndAmount Fee);
    private sealed record Allocation(List<OrderDetail> Lines, List<BatchInventory> Batches, decimal Total);
    private async Task<Preparation> Plan(string addressId, CancellationToken ct)
    {
        var customer = currentCustomer.RequireCustomerId(); ServiceRules.Id(addressId);
        var cart = await checkoutRepository.GetCheckoutCartAsync(customer, ct); ServiceRules.Require(cart.Items.Count > 0, "EMPTY_CART", 422);
        var address = await checkoutRepository.GetOwnedAddressAsync(customer, addressId, ct);
        var distance = await distanceCalculator.CalculateAsync(address.AddressId, ct);
        return new(customer, cart, address, distance, deliveryFeePolicy.Quote(distance));
    }
    private async Task<Allocation> Allocate(Cart cart, CancellationToken ct)
    {
        var batches = ServiceRules.Fefo(await checkoutRepository.LockFefoBatchesAsync(cart.Items.Select(i => i.ProductId).ToList(), ct));
        var lines = new List<OrderDetail>(); decimal total = 0;
        foreach (var item in cart.Items)
        {
            ServiceRules.Require(item.Quantity > 0, "INVALID_QUANTITY"); var remaining = item.Quantity;
            foreach (var b in batches.Where(b => b.ProductId == item.ProductId))
            {
                var qty = Math.Min(remaining, b.CurrentStock - b.ReservedStock); if (qty == 0) continue;
                var price = pricing.Quote(b, DateTimeOffset.UtcNow);
                lines.Add(new() { ProductId = item.ProductId, BatchId = b.BatchId, Quantity = qty, UnitPrice = price, LineTotal = new(price.Units * qty), DiscountAmount = new(0) });
                total += price.Units * qty; remaining -= qty; if (remaining == 0) break;
            }
            ServiceRules.Require(remaining == 0, "INSUFFICIENT_STOCK", 409);
        }
        return new(lines, batches, total);
    }
    public async Task<CheckoutSummaryDto> PrepareCheckoutAsync(CheckoutInputDto request, CancellationToken signal)
    {
        var p = await Plan(request.AddressId, signal); var a = await Allocate(p.Cart, signal);
        return new()
        {
            SubTotal = ServiceRules.Money(a.Total),
            ShippingFee = p.Fee.ToWire(),
            DistanceKm = p.Distance,
            Total = ServiceRules.Money(a.Total + p.Fee.Units),
            Lines = a.Lines.Select(l => new CheckoutLineDto { ProductId = l.ProductId, BatchId = l.BatchId, Quantity = l.Quantity, UnitPrice = l.UnitPrice.ToWire(), Discount = "0" }).ToList()
        };
    }
    // Fixed property order and unescaped Unicode preserve the Node baseline's request fingerprint.
    public static string RequestHash(PlaceOrderDto request)
    {
        var json = "{\"AddressId\":" + LegacyJsonString(request.AddressId) + ",\"PaymentMethod\":" + LegacyJsonString(request.PaymentMethod.ToString()) + ",\"CheckoutReference\":" + LegacyJsonString(request.CheckoutReference) + "}";
        return Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(json)));
    }
    // Match JSON.stringify's escaping byte-for-byte for existing persisted fingerprints.
    private static string LegacyJsonString(string text)
    {
        var output = new StringBuilder("\"");
        for (var i = 0; i < text.Length; i++)
        {
            var c = text[i];
            var escape = c switch { '"' => "\\\"", '\\' => "\\\\", '\b' => "\\b", '\f' => "\\f", '\n' => "\\n", '\r' => "\\r", '\t' => "\\t", _ => null };
            if (escape is not null) output.Append(escape);
            else if (char.IsHighSurrogate(c) && i + 1 < text.Length && char.IsLowSurrogate(text[i + 1])) { output.Append(c).Append(text[++i]); }
            else if (c < 32 || char.IsSurrogate(c)) output.Append("\\u").Append(((int)c).ToString("x4", CultureInfo.InvariantCulture));
            else output.Append(c);
        }
        return output.Append('"').ToString();
    }
    public async Task<OrderConfirmationDto> PlaceOrderAsync(PlaceOrderDto request, CancellationToken signal)
    {
        ServiceRules.Require(Enum.IsDefined(request.PaymentMethod), "INVALID_PAYMENT_METHOD");
        var customer = currentCustomer.RequireCustomerId(); ServiceRules.Id(request.AddressId);
        ServiceRules.Key(request.CheckoutReference); ServiceRules.Key(request.IdempotencyKey);
        if (request.PaymentMethod == PaymentMethod.VietQr) throw new DomainException("PRE_ACCEPTANCE_PAYMENT_CORRELATION_TBD", 503);
        Preparation? preparation = null; Exception? preparationError = null;
        try { preparation = await Plan(request.AddressId, signal); } catch (Exception e) when (e is not OperationCanceledException) { preparationError = e; }
        var result = await unitOfWork.ExecuteAsync(async ct =>
        {
            var claim = (CheckoutClaim)await checkoutRepository.ClaimCheckoutAsync(customer, request.CheckoutReference, request.IdempotencyKey, RequestHash(request), ct);
            if (claim.Replay) return (Confirmation: JsonSerializer.Deserialize<OrderConfirmationDto>(claim.Response!, ApiJson.Options)!, Replay: true);
            if (preparationError is not null) System.Runtime.ExceptionServices.ExceptionDispatchInfo.Capture(preparationError).Throw();
            var p = preparation!; var cart = await checkoutRepository.GetCheckoutCartAsync(customer, ct);
            ServiceRules.Require(cart.Items.Count > 0, "EMPTY_CART", 422);
            var address = await checkoutRepository.GetOwnedAddressAsync(customer, request.AddressId, ct);
            ServiceRules.Require(address.StreetAddress == p.Address.StreetAddress && address.Latitude == p.Address.Latitude && address.Longitude == p.Address.Longitude, "CHECKOUT_ADDRESS_CHANGED", 409);
            var a = await Allocate(cart, ct);
            var order = new Order
            {
                OrderNumber = Guid.NewGuid().ToString(),
                CustomerId = customer,
                DeliveryAddressId = address.AddressId,
                OrderDate = DateTimeOffset.UtcNow,
                SubTotal = new(a.Total),
                DeliveryDistance = p.Distance,
                ShippingFee = p.Fee,
                TotalAmount = new(a.Total + p.Fee.Units),
                PaymentMethod = request.PaymentMethod,
                PaymentStatus = PaymentStatus.Unpaid,
                Details = a.Lines
            };
            var aggregate = "checkout:" + customer + ":" + request.CheckoutReference;
            await orderStateMachine.ProcessEventAsync(new(aggregate, customer, order, a.Batches, true), new() { Event = "acceptOrder", AggregateId = aggregate, EventId = request.IdempotencyKey }, ct);
            await checkoutRepository.SaveOrderAsync(order, ct); await checkoutRepository.ClearCartAsync(cart.CartId, ct);
            var confirmation = new OrderConfirmationDto { OrderId = order.OrderId, OrderNumber = order.OrderNumber, Status = order.OrderStatus, PaymentStatus = order.PaymentStatus, Total = order.TotalAmount.ToWire() };
            // Persist the same string-enum wire representation returned by ASP.NET.
            await checkoutRepository.CompleteCheckoutAsync(customer, request.CheckoutReference, request.IdempotencyKey, JsonSerializer.SerializeToElement(confirmation, ApiJson.Options), ct);
            return (Confirmation: confirmation, Replay: false);
        }, signal);
        if (!result.Replay)
            try { await notificationGateway.PublishAsync(new() { OrderId = result.Confirmation.OrderId, EventCode = "ORDER_ACCEPTED" }, signal); }
            catch (Exception e) { logger.LogWarning(e, "Notification failed after committed order {OrderId}", result.Confirmation.OrderId); }
        return result.Confirmation;
    }
    public Task<PaymentQrDto> CreatePaymentQrAsync(PaymentQrRequestDto request, CancellationToken signal)
    { currentCustomer.RequireCustomerId(); ServiceRules.Key(request.CheckoutReference); throw new DomainException("PRE_ACCEPTANCE_PAYMENT_CORRELATION_TBD", 503); }
    public async Task<PaymentResultDto> HandleVerifiedPaymentAsync(PaymentNoticeDto request, CancellationToken signal)
    {
        var verified = await paymentGateway.VerifyNoticeAsync(request, signal);
        ServiceRules.Require(!string.IsNullOrEmpty(verified.ProviderReference) && !string.IsNullOrEmpty(verified.CheckoutReference), "UNVERIFIED_PAYMENT", 403);
        throw new DomainException("PAYMENT_CORRELATION_AND_LATE_PAYMENT_POLICY_TBD", 503);
    }
}
