using Travels.Domain.SeedWork;

namespace Travels.Domain.Aggregates.Travellers
{
    public class Traveller : EntityBase<int>, IAggregateRoot
    {
        public string Name { get; init; }
    }
}
