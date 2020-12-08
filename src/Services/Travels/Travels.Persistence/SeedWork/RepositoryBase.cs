using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Travels.Domain.SeedWork;

namespace Travels.Persistence.SeedWork
{
    public abstract class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : EntityBase<TKey>, IAggregateRoot  
    {
        protected readonly DbContext _context;
        private DbSet<TEntity> _dbSet;

        public RepositoryBase(DbContext dbContext)
        {
            _context = dbContext;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity> GetAsync(TKey id)
            => await _dbSet.SingleOrDefaultAsync<TEntity>(e => e.Id.Equals(id));

        public TEntity Save(TEntity entity)
        {
            if (entity.Id.Equals(default))
                return _dbSet.Add(entity).Entity;
            else
                return _dbSet.Update(entity).Entity;
        }

        public async Task<TEntity> DeleteAsync(TKey id)
        {
            var entity = await GetAsync(id);
            return _dbSet.Remove(entity).Entity;
        }
    }
}
