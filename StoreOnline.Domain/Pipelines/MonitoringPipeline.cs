using MediatR;
using System.Diagnostics;

namespace StoreOnline.Domain.Pipelines;

public class MonitoringPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{

    private static readonly ActivitySource ActivitySource = new ActivitySource("StoreOnline");
    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        using var activity = ActivitySource.StartActivity("UseCase", ActivityKind.Internal, default(ActivityContext));

        return next();
    }
}
