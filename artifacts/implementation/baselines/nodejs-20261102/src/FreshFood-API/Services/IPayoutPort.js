/**
 * Design revision 2026-11-02: IPayoutPort
 * Ownership: FreshFood-API.Services
 * + RequestAsync(refundId: EntityId, signal: AbortSignal): Promise<PayoutOutcomeDto>
 */
/** IPayoutPort — FreshFood-API.Services; approved design source: detailed-class-model.json. */
export class IPayoutPort {
  async RequestAsync(refundId, signal) { throw Object.assign(new Error("IPayoutPort.RequestAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
}
