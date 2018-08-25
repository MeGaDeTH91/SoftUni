namespace MyBlog.Data.EntityConfiguration.BooksConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyBlog.Models.Books;

    public class BookAuthorGenreConfig : IEntityTypeConfiguration<BookAuthorGenre>
    {
        public void Configure(EntityTypeBuilder<BookAuthorGenre> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasAlternateKey(x => x.AuthorGenreName);

            builder.HasMany(x => x.Authors)
                .WithOne(x => x.BookAuthorGenre)
                .HasForeignKey(x => x.BookAuthorGenreId);
        }
    }
}
