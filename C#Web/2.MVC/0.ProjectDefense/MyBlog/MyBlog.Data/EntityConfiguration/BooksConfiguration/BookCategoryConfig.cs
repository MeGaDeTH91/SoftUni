namespace MyBlog.Data.EntityConfiguration.BooksConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyBlog.Models.Books;

    public class BookCategoryConfig : IEntityTypeConfiguration<BookCategory>
    {
        public void Configure(EntityTypeBuilder<BookCategory> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasAlternateKey(x => x.BookCategoryName);

            builder.Property(x => x.BookCategoryName)
                .IsRequired(true);

            builder.HasMany(x => x.Books)
                .WithOne(x => x.BookCategory)
                .HasForeignKey(x => x.BookCategoryId);
        }
    }
}
