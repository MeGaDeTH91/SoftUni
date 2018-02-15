namespace FastFood.Data.EntityConfiguration
{
    using FastFood.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class OrderItemsConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(x => new { x.ItemId, x.OrderId });

            builder.Property(x => x.Quantity)
                .IsRequired(true);
        }
    }
}
