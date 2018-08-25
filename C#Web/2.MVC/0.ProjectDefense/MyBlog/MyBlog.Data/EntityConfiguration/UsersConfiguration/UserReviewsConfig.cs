namespace MyBlog.Data.EntityConfiguration.UsersConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyBlog.Models.Users;

    public class UserReviewsConfig : IEntityTypeConfiguration<UserReviews>
    {
        public void Configure(EntityTypeBuilder<UserReviews> builder)
        {
            builder.HasKey(x => new { x.ReviewId, x.UserId });

            builder.HasOne(x => x.User)
                .WithMany(x => x.FavouriteReviews)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Review)
                .WithMany(x => x.AddedToFavoritesBy)
                .HasForeignKey(x => x.ReviewId);

            builder.Property(x => x.AddedToFavouritesOn)
                .IsRequired(true);
        }
    }
}
