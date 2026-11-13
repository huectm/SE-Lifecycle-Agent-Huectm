/**
 * Design revision 2026-11-02: IUnitOfWork
 * Ownership: FreshFood.Reposistory.Repository
 * + ExecuteAsync(work: TransactionWork, signal: AbortSignal): Promise<void>
 */
/** IUnitOfWork — FreshFood.Reposistory.Repository; approved design source: detailed-class-model.json. */
export class IUnitOfWork {
  async ExecuteAsync(work, signal) { throw Object.assign(new Error("IUnitOfWork.ExecuteAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
}
