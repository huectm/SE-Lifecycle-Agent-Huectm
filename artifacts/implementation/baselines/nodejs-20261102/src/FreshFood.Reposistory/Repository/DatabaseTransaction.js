/**
 * Design revision 2026-11-02: DatabaseTransaction
 * Ownership: FreshFood.Reposistory.Repository
 * + CommitAsync(signal: AbortSignal): Promise<void>
 * + RollbackAsync(signal: AbortSignal): Promise<void>
 */
/** DatabaseTransaction — FreshFood.Reposistory.Repository; approved design source: detailed-class-model.json. */
export class DatabaseTransaction {
  async CommitAsync(signal) { throw Object.assign(new Error("DatabaseTransaction.CommitAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async RollbackAsync(signal) { throw Object.assign(new Error("DatabaseTransaction.RollbackAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
}
