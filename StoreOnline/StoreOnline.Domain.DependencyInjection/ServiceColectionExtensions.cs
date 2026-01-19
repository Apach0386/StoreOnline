using Confluent.Kafka;
using Domain.Exceptions;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using StoreOnline.Domain.Pipelines;

namespace Domain.Dependency.Injection;

public static class ServiceColectionExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(config => config
        .AddOpenBehavior(typeof(MonitoringPipeline<,>))
        .AddOpenBehavior(typeof(TransactionPipeline<,>))
        .RegisterServicesFromAssembly(typeof(DomainException).Assembly));
        services.AddValidatorsFromAssemblyContaining<DomainException>(includeInternalTypes: true);
        services.AddSingleton<IProducer<Null, string>>(sp =>
        {
            var config = new ProducerConfig
            {
                BootstrapServers = configuration.GetConnectionString("kafka")
            };
            return new ProducerBuilder<Null, string>(config).Build();
        });



        return services;
    }
}
