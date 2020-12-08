using System.Threading.Tasks;
using Travels.Application.Extensions;
using Travels.Domain.SeedWork;

namespace Travels.Application.SeedWork
{
    public abstract class CrudServiceBase<TDto, TEntity, TKey> : ICrudServiceBase<TDto, TKey>
        where TDto : new()
        where TEntity : IAggregateRoot, new()   
    {
        private readonly IUnitOfWork _unitOfWork;
        protected readonly IRepository<TEntity, TKey> _repository;

        public CrudServiceBase(IUnitOfWork unitOfWork
            , IRepository<TEntity, TKey> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<TDto> GetAsync(TKey id)
        {
            var entity = await _repository.GetAsync(id);
            return entity.Inject<TDto>();
        }

        public async Task<TDto> SaveAsync(TDto dto)
        {
            var modifiedEntity = _repository.Save(dto.Inject<TEntity>());
            await _unitOfWork.SaveChangesAsync();
            return modifiedEntity.Inject<TDto>();
        }

        public async Task<TDto> DeleteAsync(TKey id)
        {
            var deletedEntity = await _repository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return deletedEntity.Inject<TDto>();
        }
    }
}
