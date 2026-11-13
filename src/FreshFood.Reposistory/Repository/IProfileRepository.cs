namespace FreshFood.Reposistory.Repository;

public interface IProfileRepository
{
    Task<Customer> GetCustomerAsync(string customerId, CancellationToken signal);
    Task<List<CustomerAddress>> GetAddressesAsync(string customerId, CancellationToken signal);
    Task<bool> HasActiveOrderAsync(string customerId, string addressId, CancellationToken signal);
    Task SaveCustomerAsync(Customer customer, CancellationToken signal);
    Task SaveAddressAsync(CustomerAddress address, CancellationToken signal);
    Task DeleteAddressAsync(string customerId, string addressId, CancellationToken signal);
}
