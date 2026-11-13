/**
 * Design revision 2026-11-02: IProfileRepository
 * Ownership: FreshFood.Reposistory.Repository
 * + GetCustomerAsync(customerId: EntityId, signal: AbortSignal): Promise<Customer>
 * + GetAddressesAsync(customerId: EntityId, signal: AbortSignal): Promise<ReadonlyArray<CustomerAddress>>
 * + HasActiveOrderAsync(customerId: EntityId, addressId: EntityId, signal: AbortSignal): Promise<boolean>
 * + SaveCustomerAsync(customer: Customer, signal: AbortSignal): Promise<void>
 * + SaveAddressAsync(address: CustomerAddress, signal: AbortSignal): Promise<void>
 * + DeleteAddressAsync(customerId: EntityId, addressId: EntityId, signal: AbortSignal): Promise<void>
 */
/** IProfileRepository — FreshFood.Reposistory.Repository; approved design source: detailed-class-model.json. */
export class IProfileRepository {
  async GetCustomerAsync(customerId, signal) { throw Object.assign(new Error("IProfileRepository.GetCustomerAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async GetAddressesAsync(customerId, signal) { throw Object.assign(new Error("IProfileRepository.GetAddressesAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async HasActiveOrderAsync(customerId, addressId, signal) { throw Object.assign(new Error("IProfileRepository.HasActiveOrderAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async SaveCustomerAsync(customer, signal) { throw Object.assign(new Error("IProfileRepository.SaveCustomerAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async SaveAddressAsync(address, signal) { throw Object.assign(new Error("IProfileRepository.SaveAddressAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async DeleteAddressAsync(customerId, addressId, signal) { throw Object.assign(new Error("IProfileRepository.DeleteAddressAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
}
