using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrainerHub.Domain.UseCases.BookUseCases.Abstract;
using TrainerHub.Storage.Storages;


namespace Storage.Dependency.Injection
{
   public static class StorageServiceCollectionExtensiones
    {
        static public IServiceCollection AddStorage(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<TrainerDBContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("postgres"), b => b.MigrationsAssembly(typeof(TrainerDBContext).Assembly)));
            
            services.AddScoped<IBookStorage, BookStorage>();

            return services;
        }
    }
}
