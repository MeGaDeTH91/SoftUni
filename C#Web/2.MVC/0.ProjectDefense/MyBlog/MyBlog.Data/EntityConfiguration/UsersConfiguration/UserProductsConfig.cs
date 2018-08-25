namespace MyBlog.Data.EntityConfiguration.UsersConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyBlog.Models.Users;

    public class UserProductsConfig : IEntityTypeConfiguration<UserProducts>
    {
        public void Configure(EntityTypeBuilder<UserProducts> builder)
        {
            builder.HasKey(x => new { x.ProductId, x.UserId });

            builder.HasOne(x => x.User)
                .WithMany(x => x.BoughtProducts)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.BoughtBy)
                .HasForeignKey(x => x.ProductId);

            builder.Property(x => x.BoughtOn)
                .IsRequired(true);
        }
    }
}
