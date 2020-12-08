namespace Travels.Domain.SeedWork
{
    public abstract class EntityBase<TKey> 
    {
        public TKey Id { get; init; }
    }
}
