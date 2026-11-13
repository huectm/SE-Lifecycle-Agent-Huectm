/**
 * Design revision 2026-11-02: PostgreSqlSession
 * Ownership: FreshFood.Reposistory.Repository.Implements
 * - connection: DatabaseConnection
 * - transaction: DatabaseTransaction?
 * + PostgreSqlSession(connection: DatabaseConnection)
 * + BeginAsync(signal: AbortSignal): Promise<void>
 * + CommitAsync(signal: AbortSignal): Promise<void>
 * + RollbackAsync(signal: AbortSignal): Promise<void>
 */
export class PostgreSqlSession {
  constructor(connection) { this.connection = connection; this.active = false; }
  async BeginAsync(signal) { if (this.active) throw new Error('Nested transaction prohibited'); await this.connection.QueryAsync('BEGIN',[],signal); this.active=true; }
  async CommitAsync(signal) { if (!this.active) throw new Error('No active transaction'); await this.connection.QueryAsync('COMMIT',[],signal); this.active=false; }
  async RollbackAsync(signal) { if(this.active) { try { await this.connection.QueryAsync('ROLLBACK',[],signal); } finally { this.active=false; } } }
}
