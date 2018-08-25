namespace MyBlog.Data.EntityConfiguration.UsersConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyBlog.Models.Users;

    public class UserBrandsConfig : IEntityTypeConfiguration<UserBrands>
    {
        public void Configure(EntityTypeBuilder<UserBrands> builder)
        {
            builder.HasKey(x => new { x.BrandId, x.UserId });

            builder.HasOne(x => x.User)
                .WithMany(x => x.FavouriteBrands)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Brand)
                .WithMany(x => x.AddedToFavoritesBy)
                .HasForeignKey(x => x.BrandId);

            builder.Property(x => x.AddedToFavouritesOn)
                .IsRequired(true);
        }
    }
}
