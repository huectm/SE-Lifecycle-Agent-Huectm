/**
 * Design revision 2026-11-02: ProfileRepository
 * Ownership: FreshFood.Reposistory.Repository.Implements
 * - session: IRepositorySession
 * + ProfileRepository(session: IRepositorySession)
 * + GetCustomerAsync(customerId: EntityId, signal: AbortSignal): Promise<Customer>
 * + GetAddressesAsync(customerId: EntityId, signal: AbortSignal): Promise<ReadonlyArray<CustomerAddress>>
 * + HasActiveOrderAsync(customerId: EntityId, addressId: EntityId, signal: AbortSignal): Promise<boolean>
 * + SaveCustomerAsync(customer: Customer, signal: AbortSignal): Promise<void>
 * + SaveAddressAsync(address: CustomerAddress, signal: AbortSignal): Promise<void>
 * + DeleteAddressAsync(customerId: EntityId, addressId: EntityId, signal: AbortSignal): Promise<void>
 */
import { encode, rows, one, lock, cart as loadCart, saveCart, batches as loadBatches, orders, gap } from './sql.js';
export class ProfileRepository {
  constructor(session) {this.session=session;}
  async GetCustomerAsync(customerId, signal) { return one(this.session,'SELECT * FROM customers WHERE customer_id=$1'+lock(this.session),[customerId],signal); }
  async GetAddressesAsync(customerId, signal) { return rows(this.session,'SELECT * FROM customer_addresses WHERE customer_id=$1 ORDER BY address_id'+lock(this.session),[customerId],signal); }
  async HasActiveOrderAsync(customerId, addressId, signal) { return (await rows(this.session,"SELECT order_id FROM orders WHERE customer_id=$1 AND delivery_address_id=$2 AND order_status NOT IN ('DELIVERED','CANCELLED','RETURNED') LIMIT 1",[customerId,addressId],signal)).length>0; }
  async SaveCustomerAsync(customer, signal) { await rows(this.session,'UPDATE customers SET full_name=$1,email=$2 WHERE customer_id=$3',[customer.FullName,customer.Email,customer.CustomerId],signal); }
  async SaveAddressAsync(address, signal) { if(!this.session.active)throw new Error('Address writes require transaction');
await rows(this.session,'SELECT customer_id FROM customers WHERE customer_id=$1 FOR UPDATE',[address.CustomerId],signal);
if(address.IsDefault)await rows(this.session,'UPDATE customer_addresses SET is_default=FALSE WHERE customer_id=$1',[address.CustomerId],signal);
const values=[address.CustomerId,address.RecipientName,address.RecipientPhone,address.StreetAddress,address.Latitude,address.Longitude,address.IsDefault];
const result=address.AddressId?await one(this.session,'UPDATE customer_addresses SET recipient_name=$2,recipient_phone=$3,street_address=$4,latitude=$5,longitude=$6,is_default=$7 WHERE customer_id=$1 AND address_id=$8 RETURNING *',[...values,address.AddressId],signal):await one(this.session,'INSERT INTO customer_addresses(customer_id,recipient_name,recipient_phone,street_address,latitude,longitude,is_default) VALUES($1,$2,$3,$4,$5,$6,$7) RETURNING *',values,signal);
if(!result)throw Object.assign(new Error('Address not owned'),{code:'NOT_FOUND',status:404});Object.assign(address,result); }
  async DeleteAddressAsync(customerId, addressId, signal) { await rows(this.session,'DELETE FROM customer_addresses WHERE customer_id=$1 AND address_id=$2',[customerId,addressId],signal); }
}
