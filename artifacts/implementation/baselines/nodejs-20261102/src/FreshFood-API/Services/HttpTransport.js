/**
 * Design revision 2026-11-02: HttpTransport
 * Ownership: FreshFood-API.Services
 * + SendAsync(url: string, payload: unknown, signal: AbortSignal): Promise<unknown>
 */
/** HttpTransport — FreshFood-API.Services; approved design source: detailed-class-model.json. */
export class HttpTransport {
  async SendAsync(url, payload, signal) { throw Object.assign(new Error("HttpTransport.SendAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
}
