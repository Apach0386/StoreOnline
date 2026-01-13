using MediatR;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace StoreOnline.Domain.Pipelines;

public class MonitoringPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    public MonitoringPipeline(IMeterFactory meterFactory)
    {
        _meterFactory = meterFactory;
        _meter = _meterFactory.Create("StoreOnline.Domain");
    }

    private static readonly ActivitySource ActivitySource = new ActivitySource("StoreOnline");    
    private readonly IMeterFactory _meterFactory;
    private readonly Meter _meter;
    private static readonly ConcurrentDictionary<string, Counter<long>> _counters = new();

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        using var activity = ActivitySource.StartActivity("UseCase", ActivityKind.Internal, default(ActivityContext));

		try
		{
            _counters.GetOrAdd($"{typeof(TRequest).Name}.Called", 
                _ => 
            _meter.CreateCounter<long>($"{typeof(TRequest).Name}.Called")).Add(1);

            return await next();
		}
		catch 
		{
			activity?.AddTag("Error",true);
			throw;
        }
    }
}
