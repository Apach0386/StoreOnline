using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace StoreOnline.API.Monitoring;

public static class OpenTelemetryServiceCollectionExtensions
{
    public static IServiceCollection AddOpenTelemetryMonitoring(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOpenTelemetry()
            .WithTracing(builder =>
            {
                builder
                .ConfigureResource(conf => conf.AddService("StoreOnline.API"))
                    .AddAspNetCoreInstrumentation(options => 
                    {
                        options.Filter += context =>
                        !context.Request.Path.Value!.Contains("swagger", StringComparison.InvariantCultureIgnoreCase);
                    })
                    //.AddHttpClientInstrumentation()
                    .AddEntityFrameworkCoreInstrumentation()
                    .AddSource("StoreOnline")
                    .AddJaegerExporter(options =>
                    {
                        options.AgentHost = configuration.GetValue<string>("Jaeger:Host");
                        options.AgentPort = configuration.GetValue<int>("Jaeger:Port");
                    });
            });
        return services;
    }
}
