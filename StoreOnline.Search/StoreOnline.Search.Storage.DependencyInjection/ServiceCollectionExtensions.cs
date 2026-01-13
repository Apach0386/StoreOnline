using Microsoft.Extensions.DependencyInjection;
using OpenSearch.Client;
using StoreOnline.Search.Domain.UseCases.Commands.Index;
using StoreOnline.Search.Storage.Entities;
using StoreOnline.Search.Storage.Storages;

namespace StoreOnline.Search.Storage.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddStoreOnlineSearchStorage(this IServiceCollection services, string connectionString)
    {
        services.AddSingleton<IOpenSearchClient>(new OpenSearchClient(new Uri(connectionString)) 
        {
            ConnectionSettings = 
            {
                 DefaultIndices = 
                {
                    [typeof (SearchProductEntity)] = "storeonline-products"
                }
            }
        });
        services.AddScoped<IIndexStorage, IndexStorage>();

        return services;
    }
}
