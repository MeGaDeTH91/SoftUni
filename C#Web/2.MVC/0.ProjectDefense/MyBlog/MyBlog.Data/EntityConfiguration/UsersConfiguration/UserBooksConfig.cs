namespace MyBlog.Data.EntityConfiguration.UsersConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyBlog.Models.Users;

    public class UserBooksConfig : IEntityTypeConfiguration<UserBooks>
    {
        public void Configure(EntityTypeBuilder<UserBooks> builder)
        {
            builder.HasKey(x => new { x.BookId, x.UserId });

            builder.HasOne(x => x.User)
                .WithMany(x => x.FavouriteBooks)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Book)
                .WithMany(x => x.AddedToFavoritesBy)
                .HasForeignKey(x => x.BookId);

            builder.Property(x => x.AddedToFavouritesOn)
                .IsRequired(true);
        }
    }
}
