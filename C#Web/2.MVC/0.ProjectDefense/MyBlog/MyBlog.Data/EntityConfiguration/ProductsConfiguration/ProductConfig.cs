namespace MyBlog.Data.EntityConfiguration.ProductsConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyBlog.Models.ProductsForSale;

    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasAlternateKey(x => x.ProductName);

            builder.Property(x => x.Description)
                .IsRequired(true);

            builder.Property(x => x.PhotoURL)
                .IsRequired(true);

            builder.Property(x => x.HighLightVideoURL)
                .IsRequired(true);

            builder.Property(x => x.AdditionalInfoURL)
                .IsRequired(true);
        }
    }
}
