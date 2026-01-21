using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace StoreOnline.Search.API.Monitoring;

public static class OpenTelemetryServiceCollectionExtensions
{
    public static IServiceCollection AddOpenTelemetryMonitoring(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOpenTelemetry()
            .WithMetrics(builder => builder
                .AddAspNetCoreInstrumentation()
                .AddMeter("StoreOnline.Search.Api", "StoreOnline.Domain")
                .AddPrometheusExporter(opt => { opt.ScrapeEndpointPath = "/metrics"; })
                .AddView("http.server.request.duration", new ExplicitBucketHistogramConfiguration 
                {
                    Boundaries = [0.05, 0.1, 0.25, 0.5, 1, 2.5, 5, 10]
                })
                )
            .WithTracing(builder =>
            {
                builder
                .ConfigureResource(conf => conf.AddService("StoreOnline.Search.API"))
                    .AddAspNetCoreInstrumentation(options => 
                    {
                        options.Filter += context =>
                        !context.Request.Path.Value!.Contains("swagger", StringComparison.InvariantCultureIgnoreCase);
                    })
                    //.AddHttpClientInstrumentation()
                    .AddEntityFrameworkCoreInstrumentation()
                    .AddSource("StoreOnline.Search")
                    .AddJaegerExporter(options =>
                    {
                        options.AgentHost = configuration.GetValue<string>("Jaeger:Host");
                        options.AgentPort = configuration.GetValue<int>("Jaeger:Port");
                    });
            });
        return services;
    }
}
