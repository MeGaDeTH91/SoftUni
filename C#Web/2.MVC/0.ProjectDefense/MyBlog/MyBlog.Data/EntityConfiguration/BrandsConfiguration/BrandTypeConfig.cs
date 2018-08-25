namespace MyBlog.Data.EntityConfiguration.BrandsConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyBlog.Models.Brands;

    public class BrandTypeConfig : IEntityTypeConfiguration<BrandType>
    {
        public void Configure(EntityTypeBuilder<BrandType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasAlternateKey(x => x.TypeName);

            builder.HasMany(x => x.Brands)
                .WithOne(x => x.BrandType)
                .HasForeignKey(x => x.BrandTypeId);
        }
    }
}
