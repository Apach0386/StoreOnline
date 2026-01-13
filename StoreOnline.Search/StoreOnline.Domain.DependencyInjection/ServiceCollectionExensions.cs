using Microsoft.Extensions.DependencyInjection;
using StoreOnline.Search.Domain.UseCases.Commands.Index;
namespace StoreOnline.Search.Domain.DependencyInjection;

public static class ServiceCollectionExensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddMediatR(config => config        
        .RegisterServicesFromAssembly(typeof(IndexCommand).Assembly));       

        return services;
    }
}
