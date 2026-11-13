namespace FreshFood.Reposistory.Repository.Implements;

public sealed class UnitOfWork(IRepositorySession session) : IUnitOfWork
{
    public Task ExecuteAsync(Func<CancellationToken, Task> work, CancellationToken signal) =>
        ExecuteAsync(async ct => { await work(ct); return true; }, signal);
    public async Task<T> ExecuteAsync<T>(Func<CancellationToken, Task<T>> work, CancellationToken signal)
    {
        await session.BeginAsync(signal);
        try { var result = await work(signal); await session.CommitAsync(signal); return result; }
        catch { await session.RollbackAsync(CancellationToken.None); throw; }
    }
}
