/**
 * Design revision 2026-11-02: IRepositorySession
 * Ownership: FreshFood.Reposistory.Repository
 * + BeginAsync(signal: AbortSignal): Promise<void>
 * + CommitAsync(signal: AbortSignal): Promise<void>
 * + RollbackAsync(signal: AbortSignal): Promise<void>
 */
/** IRepositorySession — FreshFood.Reposistory.Repository; approved design source: detailed-class-model.json. */
export class IRepositorySession {
  async BeginAsync(signal) { throw Object.assign(new Error("IRepositorySession.BeginAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async CommitAsync(signal) { throw Object.assign(new Error("IRepositorySession.CommitAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async RollbackAsync(signal) { throw Object.assign(new Error("IRepositorySession.RollbackAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
}
