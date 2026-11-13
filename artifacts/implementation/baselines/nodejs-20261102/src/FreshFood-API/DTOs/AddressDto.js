/**
 * Design revision 2026-11-02: AddressDto
 * Ownership: FreshFood-API.DTOs
 * + AddressId: EntityId
 * + RecipientName: string
 * + RecipientPhone: string
 * + StreetAddress: string
 * + Latitude: number
 * + Longitude: number
 * + IsDefault: boolean
 */
/** AddressDto — FreshFood-API.DTOs; approved design source: detailed-class-model.json. */
export class AddressDto {
  constructor(values = {}) {
    this.AddressId = values.AddressId;
    this.RecipientName = values.RecipientName;
    this.RecipientPhone = values.RecipientPhone;
    this.StreetAddress = values.StreetAddress;
    this.Latitude = values.Latitude;
    this.Longitude = values.Longitude;
    this.IsDefault = values.IsDefault;
  }
}
