/**
 * Design revision 2026-11-02: IGeocodingGateway
 * Ownership: FreshFood-API.Services
 * + ResolveAsync(address: string, signal: AbortSignal): Promise<GeoPointDto>
 */
/** IGeocodingGateway — FreshFood-API.Services; approved design source: detailed-class-model.json. */
export class IGeocodingGateway {
  async ResolveAsync(address, signal) { throw Object.assign(new Error("IGeocodingGateway.ResolveAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
}
