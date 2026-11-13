/**
 * Design revision 2026-11-02: ICurrentCustomer
 * Ownership: FreshFood-API.Services
 * + RequireCustomerId(): EntityId
 * + GetCartIdentity(): CartIdentityDto
 */
/** ICurrentCustomer — FreshFood-API.Services; approved design source: detailed-class-model.json. */
export class ICurrentCustomer {
  RequireCustomerId() { throw Object.assign(new Error("ICurrentCustomer.RequireCustomerId: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  GetCartIdentity() { throw Object.assign(new Error("ICurrentCustomer.GetCartIdentity: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
}
