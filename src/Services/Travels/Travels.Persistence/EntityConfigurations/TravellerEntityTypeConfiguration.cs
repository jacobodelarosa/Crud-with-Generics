using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travels.Domain.Aggregates.Travellers;

namespace Travels.Persistence.EntityConfigurations
{
    public class TravellerEntityTypeConfiguration : IEntityTypeConfiguration<Traveller>
    {
        public void Configure(EntityTypeBuilder<Traveller> builder)
        {
            builder.ToTable("Travellers");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasMaxLength(50).IsRequired();
        }
    }
}
