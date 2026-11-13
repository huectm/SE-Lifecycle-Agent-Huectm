/**
 * Design revision 2026-11-02: AuthenticatedPrincipal
 * Ownership: FreshFood-API.Services
 * + CustomerId: EntityId?
 * + SessionId: string?
 * + Roles: ReadonlyArray<string>
 */
/** AuthenticatedPrincipal — FreshFood-API.Services; approved design source: detailed-class-model.json. */
export class AuthenticatedPrincipal {
  constructor(values = {}) {
    this.CustomerId = values.CustomerId;
    this.SessionId = values.SessionId;
    this.Roles = values.Roles;
  }
}
