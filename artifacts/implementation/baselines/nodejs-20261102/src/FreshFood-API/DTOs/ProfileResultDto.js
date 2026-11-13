/**
 * Design revision 2026-11-02: ProfileResultDto
 * Ownership: FreshFood-API.DTOs
 * + CustomerId: EntityId
 * + FullName: string
 * + Phone: string
 * + Email: string?
 * + Addresses: ReadonlyArray<AddressDto>
 */
/** ProfileResultDto — FreshFood-API.DTOs; approved design source: detailed-class-model.json. */
export class ProfileResultDto {
  constructor(values = {}) {
    this.CustomerId = values.CustomerId;
    this.FullName = values.FullName;
    this.Phone = values.Phone;
    this.Email = values.Email;
    this.Addresses = values.Addresses;
  }
}
