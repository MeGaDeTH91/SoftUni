namespace Stations.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Stations.Models;

    public class CustomerCardConfiguration : IEntityTypeConfiguration<CustomerCard>
    {
        public void Configure(EntityTypeBuilder<CustomerCard> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired(true)
                .HasMaxLength(128);

            builder.Property(x => x.Type)
                .HasDefaultValue(CardType.Normal);

            builder.HasMany(x => x.BoughtTickets)
                .WithOne(x => x.CustomerCard)
                .HasForeignKey(x => x.CustomerCardId);
        }
    }
}
