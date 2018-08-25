namespace MyBlog.Data.EntityConfiguration.UsersConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyBlog.Models.Users;

    public class UserGamesConfig : IEntityTypeConfiguration<UserGames>
    {
        public void Configure(EntityTypeBuilder<UserGames> builder)
        {
            builder.HasKey(x => new { x.GameId, x.UserId });

            builder.HasOne(x => x.User)
                .WithMany(x => x.FavouriteGames)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Game)
                .WithMany(x => x.AddedToFavoritesBy)
                .HasForeignKey(x => x.GameId);

            builder.Property(x => x.AddedToFavouritesOn)
                .IsRequired(true);
        }
    }
}
