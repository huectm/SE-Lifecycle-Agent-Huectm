/**
 * Design revision 2026-11-02: IDistanceGateway
 * Ownership: FreshFood-API.Services
 * + DrivingDistanceAsync(addressId: EntityId, signal: AbortSignal): Promise<number>
 */
/** IDistanceGateway — FreshFood-API.Services; approved design source: detailed-class-model.json. */
export class IDistanceGateway {
  async DrivingDistanceAsync(addressId, signal) { throw Object.assign(new Error("IDistanceGateway.DrivingDistanceAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
}
