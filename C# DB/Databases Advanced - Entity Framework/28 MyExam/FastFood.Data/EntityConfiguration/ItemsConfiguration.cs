namespace FastFood.Data.EntityConfiguration
{
    using FastFood.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ItemsConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasAlternateKey(x => x.Name);

            builder.Property(x => x.Name)
                .IsRequired(true)
                .HasMaxLength(30);

            builder.Property(x => x.CategoryId)
                .IsRequired(true);

            builder.Property(x => x.Price)
                .IsRequired(true);

            builder.HasMany(x => x.OrderItems)
                .WithOne(x => x.Item)
                .HasForeignKey(x => x.ItemId);
        }
    }
}
