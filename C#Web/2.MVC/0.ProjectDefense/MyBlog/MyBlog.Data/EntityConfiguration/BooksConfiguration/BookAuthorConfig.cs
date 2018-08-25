namespace MyBlog.Data.EntityConfiguration.BooksConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyBlog.Models.Books;

    public class BookAuthorConfig : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasAlternateKey(x => x.FullName);

            builder.Property(x => x.Description)
                .IsRequired(true);

            builder.Property(x => x.PhotoURL)
                .IsRequired(true);

            builder.Property(x => x.AdditionalInfoURL)
                .IsRequired(true);

            builder.HasMany(x => x.Books)
                .WithOne(x => x.BookAuthor)
                .HasForeignKey(x => x.BookAuthorId);
        }
    }
}
