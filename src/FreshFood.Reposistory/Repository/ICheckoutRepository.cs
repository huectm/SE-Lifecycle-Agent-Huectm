namespace FreshFood.Reposistory.Repository;

public interface ICheckoutRepository
{
    Task<Cart> GetCheckoutCartAsync(string customerId, CancellationToken signal);
    Task<CustomerAddress> GetOwnedAddressAsync(string customerId, string addressId, CancellationToken signal);
    Task<List<BatchInventory>> LockFefoBatchesAsync(List<string> productIds, CancellationToken signal);
    Task SaveOrderAsync(Order order, CancellationToken signal);
    Task<bool> SavePaymentOnceAsync(OrderPayment payment, CancellationToken signal);
    Task ClearCartAsync(string cartId, CancellationToken signal);
    Task<object> ClaimCheckoutAsync(string customerId, string reference, string key, string requestHash, CancellationToken signal);
    Task CompleteCheckoutAsync(string customerId, string reference, string key, object response, CancellationToken signal);
}
