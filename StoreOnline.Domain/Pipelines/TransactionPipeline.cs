using MediatR;
using StoreOnline.Domain.Pipelines.Abstractions;
using StoreOnline.Domain.Pipelines.Markers;

namespace StoreOnline.Domain.Pipelines;

public class TransactionPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly ITransactionStorage _transactionStorage;

    public TransactionPipeline(ITransactionStorage transactionStorage)
    {
        _transactionStorage = transactionStorage;
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (request is not ITransactionMarker)
        {
            return await next.Invoke();
        }

        await _transactionStorage.BeginTransaction(cancellationToken);
        try
        {
            var response = await next.Invoke();
            await _transactionStorage.CommitAsync(cancellationToken);
            return response;
        }
        catch
        {
            await _transactionStorage.RollbackAsync(cancellationToken);
            throw;
        }

    }
}
