/**
 * Design revision 2026-11-02: CurrentCustomer
 * Ownership: FreshFood-API.Services.Implements
 * - principal: AuthenticatedPrincipal
 * + CurrentCustomer(principal: AuthenticatedPrincipal)
 * + RequireCustomerId(): EntityId
 * + GetCartIdentity(): CartIdentityDto
 */
import { ApiError } from './shared.js';
export class CurrentCustomer {
  constructor(principal) { this.principal = principal; }
  RequireCustomerId() { if (!this.principal?.CustomerId) throw new ApiError('AUTHENTICATION_REQUIRED',401); return this.principal.CustomerId; }
  GetCartIdentity() { if (!this.principal?.CustomerId && !this.principal?.SessionId) throw new ApiError('SESSION_REQUIRED',401); return {CustomerId:this.principal.CustomerId,SessionId:this.principal.SessionId}; }
}
