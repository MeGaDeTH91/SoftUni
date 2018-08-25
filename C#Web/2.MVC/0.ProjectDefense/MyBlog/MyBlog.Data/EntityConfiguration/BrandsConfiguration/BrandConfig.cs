namespace MyBlog.Data.EntityConfiguration.BrandsConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyBlog.Models.Brands;

    public class BrandConfig : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasAlternateKey(x => x.BrandName);

            builder.Property(x => x.BrandDescription)
                .IsRequired(true);

            builder.Property(x => x.BrandImageURL)
                .IsRequired(true);

            builder.Property(x => x.AdditionalInfoURL)
                .IsRequired(true);

            builder.HasMany(x => x.Instruments)
                .WithOne(x => x.Brand)
                .HasForeignKey(x => x.BrandId);

            builder.HasMany(x => x.Games)
                .WithOne(x => x.Brand)
                .HasForeignKey(x => x.BrandId);

            builder.HasMany(x => x.Products)
                .WithOne(x => x.Brand)
                .HasForeignKey(x => x.BrandId);
        }
    }
}
