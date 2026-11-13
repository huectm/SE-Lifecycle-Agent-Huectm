namespace FreshFood.Reposistory.Repository.Implements;

public abstract class SqlRepository(IRepositorySession session)
{
    protected readonly IRepositorySession Session = session;
    protected string Lock => Session.Active ? " FOR UPDATE" : "";
    protected static long Id(string value) => long.TryParse(value, out var id) && id > 0 ? id : throw new DomainException("INVALID_ID");
    protected static long? OptionalId(string? value) => value is null ? null : Id(value);
    protected static string Encode<T>(T value) where T : Enum => value is PaymentMethod.VietQr ? "VIETQR" : System.Text.RegularExpressions.Regex.Replace(value.ToString(), "([a-z])([A-Z])", "$1_$2", System.Text.RegularExpressions.RegexOptions.None, TimeSpan.FromMilliseconds(100)).ToUpperInvariant();
    protected Task<List<T>> Rows<T>(string sql, CancellationToken ct, params object?[] args) where T : new() => Session.QueryAsync<T>(sql, args, ct);
    protected async Task<T?> One<T>(string sql, CancellationToken ct, params object?[] args) where T : class, new() => (await Rows<T>(sql, ct, args)).FirstOrDefault();
    protected Task<List<BatchInventory>> Batches(List<string> ids, CancellationToken ct, bool locked = false) =>
        Rows<BatchInventory>("SELECT b.* FROM batch_inventory b JOIN products p ON p.product_id=b.product_id WHERE b.product_id=ANY($1::bigint[]) AND p.is_active=TRUE AND b.sale_status IN ('ACTIVE','DISCOUNTED') AND b.expiry_date>=CURRENT_DATE AND b.current_stock>b.reserved_stock ORDER BY b.expiry_date,b.batch_id" + (locked ? " FOR UPDATE OF b" : ""), ct, ids.Select(Id).ToArray());
    protected async Task<Cart> LoadCart(string? customerId, string? sessionId, CancellationToken ct)
    {
        if (customerId is null && string.IsNullOrEmpty(sessionId)) throw new DomainException("CART_IDENTITY_REQUIRED", 401);
        var cart = await One<Cart>("SELECT * FROM carts WHERE ($1::bigint IS NOT NULL AND customer_id=$1) OR ($1::bigint IS NULL AND customer_id IS NULL AND session_id=$2)" + Lock, ct, OptionalId(customerId), sessionId);
        cart ??= (await One<Cart>("INSERT INTO carts(customer_id,session_id) VALUES($1,$2) RETURNING *", ct, OptionalId(customerId), customerId is null ? sessionId : null))!;
        cart.Items = await Rows<CartItem>("SELECT * FROM cart_items WHERE cart_id=$1 ORDER BY cart_item_id", ct, Id(cart.CartId));
        return cart;
    }
    protected void RequireTransaction() { if (!Session.Active) throw new InvalidOperationException("An active transaction is required."); }
    protected async Task SaveCart(Cart cart, CancellationToken ct)
    {
        RequireTransaction();
        await Rows<CartItem>("DELETE FROM cart_items WHERE cart_id=$1", ct, Id(cart.CartId));
        foreach (var item in cart.Items) await Rows<CartItem>("INSERT INTO cart_items(cart_id,product_id,quantity) VALUES($1,$2,$3)", ct, Id(cart.CartId), Id(item.ProductId), item.Quantity);
    }
    protected async Task<List<Order>> LoadOrders(string customerId, CancellationToken ct)
    {
        var orders = await Rows<Order>("SELECT * FROM orders WHERE customer_id=$1 ORDER BY order_date DESC,order_id DESC", ct, Id(customerId));
        foreach (var order in orders)
        {
            order.Details = await Rows<OrderDetail>("SELECT d.*,b.product_id,p.product_name FROM order_details d JOIN batch_inventory b ON b.batch_id=d.batch_id JOIN products p ON p.product_id=b.product_id WHERE d.order_id=$1 ORDER BY d.order_detail_id", ct, Id(order.OrderId));
            order.DeliveryAddress = (await One<CustomerAddress>("SELECT * FROM customer_addresses WHERE address_id=$1 AND customer_id=$2", ct, Id(order.DeliveryAddressId), Id(customerId)))!;
            order.Failure = await One<DeliveryFailure>("SELECT * FROM delivery_failures WHERE order_id=$1", ct, Id(order.OrderId));
        }
        return orders;
    }
    protected static Task Gap(string code) => Task.FromException(new DomainException(code, 503));
    protected static Task<T> Gap<T>(string code) => Task.FromException<T>(new DomainException(code, 503));
}
