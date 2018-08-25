namespace MyBlog.Data.EntityConfiguration.UsersConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyBlog.Models.Users;

    public class UserJokesConfig : IEntityTypeConfiguration<UserJokes>
    {
        public void Configure(EntityTypeBuilder<UserJokes> builder)
        {
            builder.HasKey(x => new { x.JokeId, x.UserId });

            builder.HasOne(x => x.User)
                .WithMany(x => x.FavouriteJokes)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Joke)
                .WithMany(x => x.AddedToFavoritesBy)
                .HasForeignKey(x => x.JokeId);

            builder.Property(x => x.AddedToFavouritesOn)
                .IsRequired(true);
        }
    }
}
