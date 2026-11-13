namespace FreshFood.Api.Services.Implements;

public sealed class CartService(ICartRepository cartRepository, ICurrentCustomer currentCustomer, IUnitOfWork unitOfWork, IBatchPricingPolicy pricing) : ICartService
{
    private Task<Cart> Load(CancellationToken ct) { var identity = currentCustomer.GetCartIdentity(); return cartRepository.GetAsync(identity.CustomerId, identity.SessionId, ct); }
    private async Task<CartResultDto> Result(Cart cart, CancellationToken ct)
    {
        var ids = cart.Items.Select(i => i.ProductId).ToList();
        var products = await cartRepository.GetProductsAsync(ids, ct); var batches = await cartRepository.GetSellableBatchesAsync(ids, ct);
        var result = new CartResultDto(); decimal subtotal = 0;
        foreach (var item in cart.Items)
        {
            var stock = ServiceRules.Fefo(batches.Where(b => b.ProductId == item.ProductId));
            var available = products.Any(p => p.ProductId == item.ProductId && p.IsActive) ? stock.Sum(b => b.CurrentStock - b.ReservedStock) : 0;
            var price = stock.Count > 0 ? pricing.Quote(stock[0], DateTimeOffset.UtcNow).Units : 0;
            var total = price * item.Quantity; subtotal += total;
            result.Lines.Add(new() { ProductId = item.ProductId, Quantity = item.Quantity, AvailableQuantity = available, CurrentPrice = ServiceRules.Money(price), LineTotal = ServiceRules.Money(total) });
            if (item.Quantity > available) result.Warnings.Add("UNAVAILABLE:" + item.ProductId);
        }
        result.SubTotal = ServiceRules.Money(subtotal); result.CanCheckout = result.Lines.Count > 0 && result.Warnings.Count == 0; return result;
    }
    public async Task<CartResultDto> GetCartAsync(CartIdentityDto identity, CancellationToken signal) => await Result(await Load(signal), signal);
    public Task<CartResultDto> ChangeQuantityAsync(CartChangeDto request, CancellationToken signal)
    {
        ServiceRules.Id(request.ProductId); ServiceRules.Require(request.Quantity > 0, "INVALID_QUANTITY");
        return unitOfWork.ExecuteAsync(async ct =>
        {
            var cart = await Load(ct); var products = await cartRepository.GetProductsAsync([request.ProductId], ct);
            ServiceRules.Require(products.Any(p => p.IsActive), "PRODUCT_UNAVAILABLE", 422);
            var stock = await cartRepository.GetSellableBatchesAsync([request.ProductId], ct);
            var available = stock.Where(ServiceRules.Sellable).Sum(b => b.CurrentStock - b.ReservedStock);
            ServiceRules.Require(available > 0, "OUT_OF_STOCK", 422); var actual = Math.Min(request.Quantity, available);
            cart.ChangeQuantity(request.ProductId, actual); await cartRepository.SaveAsync(cart, ct);
            var result = await Result(cart, ct); if (actual < request.Quantity) result.Warnings.Add("QUANTITY_CLAMPED:" + request.ProductId); return result;
        }, signal);
    }
    public Task<CartResultDto> RemoveItemAsync(string productId, CancellationToken signal)
    {
        ServiceRules.Id(productId);
        return unitOfWork.ExecuteAsync(async ct => { var cart = await Load(ct); cart.RemoveItem(productId); await cartRepository.SaveAsync(cart, ct); return await Result(cart, ct); }, signal);
    }
}
