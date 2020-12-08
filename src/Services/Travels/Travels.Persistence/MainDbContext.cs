using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Travels.Domain.SeedWork;

namespace Travels.Persistence
{
    public class MainDbContext : DbContext, IUnitOfWork
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
