using System.Threading.Tasks;

namespace Travels.Domain.SeedWork
{
    public interface IRepository<TEntity, TKey> 
        where TEntity : IAggregateRoot 
    {
        public Task<TEntity> GetAsync(TKey id);
        public TEntity Save(TEntity entity);
        public Task<TEntity> DeleteAsync(TKey id);
    }
}
