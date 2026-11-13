/**
 * Design revision 2026-11-02: TransactionWork
 * Ownership: FreshFood.Reposistory.Repository
 * + InvokeAsync(signal: AbortSignal): Promise<void>
 */
/** TransactionWork — FreshFood.Reposistory.Repository; approved design source: detailed-class-model.json. */
export class TransactionWork {
  async InvokeAsync(signal) { throw Object.assign(new Error("TransactionWork.InvokeAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
}
