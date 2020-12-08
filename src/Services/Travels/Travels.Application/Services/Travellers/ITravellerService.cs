using Travels.Application.Dtos;
using Travels.Application.SeedWork;

namespace Travels.Application.Services.Travellers
{
    public interface ITravellerService : ICrudServiceBase<TravellerDto, int>
    {
    }
}
