using Microsoft.EntityFrameworkCore;
using Travels.Domain.Aggregates.Travellers;
using Travels.Persistence.SeedWork;

namespace Travels.Persistence.Repositories
{
    public class TravellerRepository : RepositoryBase<Traveller, int>, ITravellerRepository
    {
        public TravellerRepository(DbContext dbContext) : base(dbContext) { }
    }
}
