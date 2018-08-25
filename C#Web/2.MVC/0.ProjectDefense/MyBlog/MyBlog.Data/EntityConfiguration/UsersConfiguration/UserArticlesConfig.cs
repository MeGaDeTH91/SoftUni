namespace MyBlog.Data.EntityConfiguration.UsersConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyBlog.Models.Users;

    public class UserArticlesConfig : IEntityTypeConfiguration<UserArticles>
    {
        public void Configure(EntityTypeBuilder<UserArticles> builder)
        {
            builder.HasKey(x => new { x.ArticleId, x.UserId });

            builder.HasOne(x => x.User)
                .WithMany(x => x.FavouriteArticles)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Article)
                .WithMany(x => x.AddedToFavoritesBy)
                .HasForeignKey(x => x.ArticleId);

            builder.Property(x => x.AddedToFavouritesOn)
                .IsRequired(true);
        }
    }
}
