using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Travels.Domain.SeedWork;
using Travels.Persistence;

namespace Travels.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
            => services
                .AddDbContextPool<MainDbContext>((serviceProvider, options) =>
                {
                    options.UseApplicationServiceProvider(serviceProvider);
                    options.UseNpgsql(configuration.GetConnectionString("MainDbContext"));
                })
               .AddScoped(provider => (DbContext)provider.GetService<MainDbContext>())
               .AddScoped<IUnitOfWork>(provider => provider.GetService<MainDbContext>());

        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            var namespacePrefix = $"{nameof(Travels)}";

            var applicationAssembly = Assembly.Load(new AssemblyName($"{namespacePrefix}.{nameof(Application)}"));
            var persistenceAssembly = Assembly.Load(new AssemblyName($"{namespacePrefix}.{nameof(Persistence)}"));
            var domainAssembly = Assembly.Load(new AssemblyName($"{namespacePrefix}.{nameof(Domain)}"));

            return services
                .Scan(typeSourceSelector => typeSourceSelector
                    .FromAssemblies(applicationAssembly, persistenceAssembly, domainAssembly)
                        .AddClasses()
                            .AsMatchingInterface()
                            .WithScopedLifetime()
                );
        }

        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
            => services
                .AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("1.0.0", new OpenApiInfo
                    {
                        Title = "Travels Api",
                        Version = "1.0.0"
                    });
                });
    }
}
