/**
 * Design revision 2026-11-02: IDistanceCalculator
 * Ownership: FreshFood-API.Services
 * + CalculateAsync(addressId: EntityId, signal: AbortSignal): Promise<number>
 */
/** IDistanceCalculator — FreshFood-API.Services; approved design source: detailed-class-model.json. */
export class IDistanceCalculator {
  async CalculateAsync(addressId, signal) { throw Object.assign(new Error("IDistanceCalculator.CalculateAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
}
