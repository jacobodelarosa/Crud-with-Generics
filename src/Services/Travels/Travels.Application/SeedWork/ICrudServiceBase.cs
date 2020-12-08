using System.Threading.Tasks;

namespace Travels.Application.SeedWork
{
    public interface ICrudServiceBase<TDto, TKey>
    {
        Task<TDto> GetAsync(TKey id);
        Task<TDto> SaveAsync(TDto dto);
        Task<TDto> DeleteAsync(TKey id);
    }
}
