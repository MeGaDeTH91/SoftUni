namespace MyBlog.Data.EntityConfiguration.ProductsConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyBlog.Models.ProductsForSale;

    public class ProductTypeConfig : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasAlternateKey(x => x.TypeName);

            builder.HasMany(x => x.Products)
                .WithOne(x => x.ProductType)
                .HasForeignKey(x => x.ProductTypeId);
        }
    }
}
