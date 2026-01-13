namespace StoreOnline.Domain.Pipelines.Abstractions;

public interface ITransactionStorage
{
    Task BeginTransaction(CancellationToken cancellationToken);
    Task CommitAsync(CancellationToken cancellationToken);
    Task RollbackAsync(CancellationToken cancellationToken);
}
