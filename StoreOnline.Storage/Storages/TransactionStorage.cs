using Microsoft.EntityFrameworkCore.Storage;
using Storage;
using StoreOnline.Domain.Pipelines.Abstractions;

namespace StoreOnline.Storage.Storages;

public class TransactionStorage : ITransactionStorage, IDisposable
{
    private readonly StoreDbContext _dbContext;

    public TransactionStorage(StoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    IDbContextTransaction? transaction = null;

    public async Task BeginTransaction(CancellationToken cancellationToken)
    {
        transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task CommitAsync(CancellationToken cancellationToken)
    {
        if (transaction == null)
        {
            throw new InvalidOperationException("Transaction has not been started.");
        }
        await transaction.CommitAsync(cancellationToken);
    }

    public async Task RollbackAsync(CancellationToken cancellationToken)
    {
        if (transaction == null)
        {
            throw new InvalidOperationException("Transaction has not been started.");
        }
        await transaction.RollbackAsync(cancellationToken);
    }

    public void Dispose()
    {
        transaction?.Dispose();
    }

    //     using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);

    //await transaction.CommitAsync(cancellationToken);
    //await transaction.RollbackAsync(cancellationToken);
}

