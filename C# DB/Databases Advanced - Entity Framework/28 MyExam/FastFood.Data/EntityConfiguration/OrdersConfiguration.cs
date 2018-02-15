namespace FastFood.Data.EntityConfiguration
{
    using FastFood.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class OrdersConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Customer)
                .IsRequired(true);

            builder.Property(x => x.DateTime)
                .IsRequired(true);

            builder.Property(x => x.Type)
                .IsRequired(true);

            builder.Ignore(x => x.TotalPrice);

            builder.Property(x => x.EmployeeId)
                .IsRequired(true);

            builder.HasMany(x => x.OrderItems)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId);
        }
    }
}
