/**
 * Design revision 2026-11-02: AddressInputDto
 * Ownership: FreshFood-API.DTOs
 * + AddressId: EntityId?
 * + RecipientName: string
 * + RecipientPhone: string
 * + StreetAddress: string
 * + IsDefault: boolean
 */
/** AddressInputDto — FreshFood-API.DTOs; approved design source: detailed-class-model.json. */
export class AddressInputDto {
  constructor(values = {}) {
    this.AddressId = values.AddressId;
    this.RecipientName = values.RecipientName;
    this.RecipientPhone = values.RecipientPhone;
    this.StreetAddress = values.StreetAddress;
    this.IsDefault = values.IsDefault;
  }
}
