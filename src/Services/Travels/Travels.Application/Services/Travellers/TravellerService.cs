using Travels.Application.Dtos;
using Travels.Application.SeedWork;
using Travels.Domain.Aggregates.Travellers;
using Travels.Domain.SeedWork;

namespace Travels.Application.Services.Travellers
{
    public class TravellerService : CrudServiceBase<TravellerDto, Traveller, int>, ITravellerService
    {
        public TravellerService(IUnitOfWork unitOfWork , ITravellerRepository repository) 
            : base(unitOfWork, repository) { }
    }
}
