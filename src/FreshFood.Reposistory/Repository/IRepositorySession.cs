namespace FreshFood.Reposistory.Repository;

public interface IRepositorySession : IAsyncDisposable
{
    bool Active { get; }
    Task BeginAsync(CancellationToken signal);
    Task CommitAsync(CancellationToken signal);
    Task RollbackAsync(CancellationToken signal);
    Task<List<T>> QueryAsync<T>(string sql, object?[] parameters, CancellationToken signal) where T : new();
}
