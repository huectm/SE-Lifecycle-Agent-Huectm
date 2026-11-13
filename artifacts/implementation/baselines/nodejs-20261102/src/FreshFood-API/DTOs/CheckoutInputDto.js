/**
 * Design revision 2026-11-02: CheckoutInputDto
 * Ownership: FreshFood-API.DTOs
 * + AddressId: EntityId
 */
/** CheckoutInputDto — FreshFood-API.DTOs; approved design source: detailed-class-model.json. */
export class CheckoutInputDto {
  constructor(values = {}) {
    this.AddressId = values.AddressId;
  }
}
