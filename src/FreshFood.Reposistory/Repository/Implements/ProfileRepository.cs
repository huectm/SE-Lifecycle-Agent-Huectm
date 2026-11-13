namespace FreshFood.Reposistory.Repository.Implements;

public sealed class ProfileRepository(IRepositorySession session) : SqlRepository(session), IProfileRepository
{
    public async Task<Customer> GetCustomerAsync(string customerId, CancellationToken signal) => await One<Customer>("SELECT * FROM customers WHERE customer_id=$1" + Lock, signal, Id(customerId)) ?? throw new DomainException("NOT_FOUND", 404);
    public Task<List<CustomerAddress>> GetAddressesAsync(string customerId, CancellationToken signal) => Rows<CustomerAddress>("SELECT * FROM customer_addresses WHERE customer_id=$1 ORDER BY address_id" + Lock, signal, Id(customerId));
    public async Task<bool> HasActiveOrderAsync(string customerId, string addressId, CancellationToken signal) => (await Rows<Order>("SELECT order_id FROM orders WHERE customer_id=$1 AND delivery_address_id=$2 AND order_status NOT IN ('DELIVERED','CANCELLED','RETURNED') LIMIT 1", signal, Id(customerId), Id(addressId))).Count > 0;
    public async Task SaveCustomerAsync(Customer customer, CancellationToken signal) { RequireTransaction(); await Rows<Customer>("UPDATE customers SET full_name=$1,email=$2 WHERE customer_id=$3", signal, customer.FullName, customer.Email, Id(customer.CustomerId)); }
    public async Task SaveAddressAsync(CustomerAddress address, CancellationToken signal)
    {
        RequireTransaction();
        await Rows<Customer>("SELECT customer_id FROM customers WHERE customer_id=$1 FOR UPDATE", signal, Id(address.CustomerId));
        if (address.IsDefault) await Rows<CustomerAddress>("UPDATE customer_addresses SET is_default=FALSE WHERE customer_id=$1", signal, Id(address.CustomerId));
        object?[] args = [Id(address.CustomerId), address.RecipientName, address.RecipientPhone, address.StreetAddress, address.Latitude, address.Longitude, address.IsDefault];
        var saved = string.IsNullOrEmpty(address.AddressId)
            ? await One<CustomerAddress>("INSERT INTO customer_addresses(customer_id,recipient_name,recipient_phone,street_address,latitude,longitude,is_default) VALUES($1,$2,$3,$4,$5,$6,$7) RETURNING *", signal, args)
            : await One<CustomerAddress>("UPDATE customer_addresses SET recipient_name=$2,recipient_phone=$3,street_address=$4,latitude=$5,longitude=$6,is_default=$7 WHERE customer_id=$1 AND address_id=$8 RETURNING *", signal, [.. args, Id(address.AddressId)]);
        address.AddressId = saved?.AddressId ?? throw new DomainException("NOT_FOUND", 404);
    }
    public async Task DeleteAddressAsync(string customerId, string addressId, CancellationToken signal) { RequireTransaction(); await Rows<CustomerAddress>("DELETE FROM customer_addresses WHERE customer_id=$1 AND address_id=$2", signal, Id(customerId), Id(addressId)); }
}
