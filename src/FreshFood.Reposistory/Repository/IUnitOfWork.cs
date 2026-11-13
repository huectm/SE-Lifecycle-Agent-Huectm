namespace FreshFood.Reposistory.Repository;

public interface IUnitOfWork
{
    Task ExecuteAsync(Func<CancellationToken, Task> work, CancellationToken signal);
    Task<T> ExecuteAsync<T>(Func<CancellationToken, Task<T>> work, CancellationToken signal);
}
