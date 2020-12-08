using Travels.Application.Dtos;
using Travels.Application.Services.Travellers;
using Travels.WebApi.SeedWork;

namespace Travels.WebApi.Controllers
{
    public class TravellersController : CrudControllerBase<TravellerDto, int>
    {
        public TravellersController(ITravellerService service) : base(service) { }
    }
}
