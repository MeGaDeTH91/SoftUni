namespace MyBlog.Data.EntityConfiguration.UsersConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyBlog.Models.Users;

    public class UserMemesConfig : IEntityTypeConfiguration<UserMemes>
    {
        public void Configure(EntityTypeBuilder<UserMemes> builder)
        {
            builder.HasKey(x => new { x.MemeId, x.UserId });

            builder.HasOne(x => x.User)
                .WithMany(x => x.FavouriteMemes)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Meme)
                .WithMany(x => x.AddedToFavoritesBy)
                .HasForeignKey(x => x.MemeId);

            builder.Property(x => x.AddedToFavouritesOn)
                .IsRequired(true);
        }
    }
}
