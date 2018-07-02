namespace SoftUni.WebServer.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SoftUni.WebServer.Models;

    public class ProductTypeConfig : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ProductTypeName)
                .IsRequired(true);

            builder.HasMany(x => x.Products)
                .WithOne(x => x.ProductType)
                .HasForeignKey(x => x.ProductTypeId);
        }
    }
}
