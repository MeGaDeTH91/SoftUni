namespace MyBlog.Data.EntityConfiguration.UsersConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyBlog.Models.Users;

    public class UserArtistsConfig : IEntityTypeConfiguration<UserArtists>
    {
        public void Configure(EntityTypeBuilder<UserArtists> builder)
        {
            builder.HasKey(x => new { x.ArtistId, x.UserId });

            builder.HasOne(x => x.User)
                .WithMany(x => x.FavouriteArtists)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Artist)
                .WithMany(x => x.AddedToFavoritesBy)
                .HasForeignKey(x => x.ArtistId);

            builder.Property(x => x.AddedToFavouritesOn)
                .IsRequired(true);
        }
    }
}
