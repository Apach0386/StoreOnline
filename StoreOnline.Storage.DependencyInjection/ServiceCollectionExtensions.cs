using Domain.UseCases.ProductUseCases.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Storage.Sorages.Products;

namespace Storage.Dependency.Injection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddStorage(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextPool<StoreDbContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("postgres"), b => b.MigrationsAssembly(typeof(StoreDbContext).Assembly)));
        services.AddAutoMapper(config => config.AddMaps(typeof(StoreDbContext).Assembly));

        services.AddScoped<IProductStorage, ProductStorage>();

        return services;
    }
}
