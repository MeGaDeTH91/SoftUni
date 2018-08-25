namespace MyBlog.Data.EntityConfiguration.UsersConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyBlog.Models.Users;

    public class UserSongsConfig : IEntityTypeConfiguration<UserSongs>
    {
        public void Configure(EntityTypeBuilder<UserSongs> builder)
        {
            builder.HasKey(x => new { x.SongId, x.UserId });

            builder.HasOne(x => x.User)
                .WithMany(x => x.FavouriteSongs)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Song)
                .WithMany(x => x.AddedToFavoritesBy)
                .HasForeignKey(x => x.SongId);

            builder.Property(x => x.AddedToFavouritesOn)
                .IsRequired(true);
        }
    }
}
