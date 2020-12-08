using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Travels.Persistence;
using Travels.WebApi.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Travels.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
            => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
          => services
                .AddConfigurationApplication()
                .AddDbContextPool<MainDbContext>((serviceProvider, options) =>
                {
                    options.UseApplicationServiceProvider(serviceProvider);
                    options.UseNpgsql(Configuration.GetConnectionString("MainDbContext"));
                })
                .AddRouting(options => options.LowercaseUrls = true)
                .AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("1.0.0", new OpenApiInfo
                    {
                        Title = "Travels Api",
                        Version = "1.0.0"
                    });
                })
                .AddControllers();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app.UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/1.0.0/swagger.json", "Travels Api Docs");
                    c.RoutePrefix = string.Empty;
                })
                .UseRouting()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
    }
}
