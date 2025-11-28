using Domain.Exceptions;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using StoreOnline.Domain.Pipelines;
using System.Transactions;

namespace Domain.Dependency.Injection;

public static class ServiceColectionExtensions 
{
    public static IServiceCollection  AddDomain(this IServiceCollection services)
    {
        services.AddMediatR(config => config
        .AddOpenBehavior(typeof(TransactionPipeline<,>))
        .RegisterServicesFromAssembly(typeof(DomainException).Assembly));
        services.AddValidatorsFromAssemblyContaining<DomainException>(includeInternalTypes:true);
        
        

        return services;
    }
}
