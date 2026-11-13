/**
 * Design revision 2026-11-02: CartIdentityDto
 * Ownership: FreshFood-API.DTOs
 * + CustomerId: EntityId? {server resolved}
 * + SessionId: string? {server resolved}
 */
/** CartIdentityDto — FreshFood-API.DTOs; approved design source: detailed-class-model.json. */
export class CartIdentityDto {
  constructor(values = {}) {
    this.CustomerId = values.CustomerId;
    this.SessionId = values.SessionId;
  }
}
