using Domain.UseCases.ProductUseCases.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StoreOnline.Domain.Pipelines.Abstractions;
using StoreOnline.Domain.UseCases.CategoryUseCases.Abstract;
using StoreOnline.Domain.UseCases.UserUseCases.Abstract;
using StoreOnline.Storage.Entities;
using StoreOnline.Storage.Storages;

namespace Storage.Dependency.Injection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddStorage(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextPool<StoreDbContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("postgres"), b => b.MigrationsAssembly(typeof(StoreDbContext).Assembly)));
        services.AddIdentityCore<User>().AddRoles<Role>().AddUserManager<UserManager<User>>().AddEntityFrameworkStores<StoreDbContext>();
        services.AddAutoMapper(config => config.AddMaps(typeof(StoreDbContext).Assembly));

        services.AddScoped<IProductStorage, ProductStorage>();
        services.AddScoped<ICategoryStorage, CategoryStorage>();
        services.AddScoped<ITransactionStorage, TransactionStorage>();
        services.AddScoped<IUserStorage, UserStorage>();
        services.AddScoped<IRoleStorage, RoleStorage>();


        return services;
    }
}
