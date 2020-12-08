namespace Travels.Application.SeedWork
{
    public abstract class DtoBase<TKey>
    {
        public TKey Id { get; init; }
    }
}
