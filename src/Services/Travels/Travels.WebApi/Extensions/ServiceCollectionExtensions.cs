using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Travels.Domain.SeedWork;
using Travels.Persistence;

namespace Travels.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddConfigurationApplication(this IServiceCollection services)
        {
            var namespacePrefix = $"{nameof(Travels)}";

            var applicationAssembly = Assembly.Load(new AssemblyName($"{namespacePrefix}.{nameof(Application)}"));
            var persistenceAssembly = Assembly.Load(new AssemblyName($"{namespacePrefix}.{nameof(Persistence)}"));
            var domainAssembly = Assembly.Load(new AssemblyName($"{namespacePrefix}.{nameof(Domain)}"));

            return services
                .AddScoped(provider => (DbContext)provider.GetService<MainDbContext>())
                .AddScoped<IUnitOfWork>(provider => provider.GetService<MainDbContext>())
                .Scan(typeSourceSelector => typeSourceSelector
                    .FromAssemblies(applicationAssembly, persistenceAssembly, domainAssembly)
                        .AddClasses()
                            .AsMatchingInterface()
                            .WithScopedLifetime()
                );
        }
    }
}
