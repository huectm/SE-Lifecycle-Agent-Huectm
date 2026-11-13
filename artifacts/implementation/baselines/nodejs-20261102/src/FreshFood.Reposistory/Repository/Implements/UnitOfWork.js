/**
 * Design revision 2026-11-02: UnitOfWork
 * Ownership: FreshFood.Reposistory.Repository.Implements
 * - session: IRepositorySession
 * + UnitOfWork(session: IRepositorySession)
 * + ExecuteAsync(work: TransactionWork, signal: AbortSignal): Promise<void>
 */
export class UnitOfWork {
  constructor(session) { this.session = session; }
  async ExecuteAsync(work, signal) {
    signal?.throwIfAborted(); await this.session.BeginAsync(signal);
    try { const result = await work(signal); signal?.throwIfAborted(); await this.session.CommitAsync(signal); return result; }
    catch (error) { await this.session.RollbackAsync().catch(() => {}); throw error; }
  }
}
