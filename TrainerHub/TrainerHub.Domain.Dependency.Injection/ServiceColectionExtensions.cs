using Microsoft.Extensions.DependencyInjection;
using TrainerHub.Domain.UseCases.BookUseCases.Model;

namespace Domain.Dependency.Injection
{
    public static class ServiceColectionExtensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddMediatR(opt => opt.RegisterServicesFromAssembly(typeof(BookModel).Assembly));
            
            return services;
        }
    }
}
