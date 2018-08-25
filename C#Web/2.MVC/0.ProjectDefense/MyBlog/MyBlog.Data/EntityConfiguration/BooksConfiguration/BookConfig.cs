namespace MyBlog.Data.EntityConfiguration.BooksConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyBlog.Models.Books;

    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasAlternateKey(x => x.Title);

            builder.Property(x => x.Title)
                .IsRequired(true);

            builder.Property(x => x.Description)
                .IsRequired(true);

            builder.Property(x => x.PhotoURL)
                .IsRequired(true);

            builder.Property(x => x.AdditionalInfoURL)
                .IsRequired(true);
        }
    }
}
