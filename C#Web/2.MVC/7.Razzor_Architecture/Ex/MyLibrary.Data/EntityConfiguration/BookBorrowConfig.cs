namespace MyLibrary.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyLibrary.Models;

    public class BookBorrowConfig : IEntityTypeConfiguration<BookBorrow>
    {
        public void Configure(EntityTypeBuilder<BookBorrow> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Book)
                .WithMany(x => x.Borrowers)
                .HasForeignKey(x => x.BookId);

            builder.HasOne(x => x.Borrower)
                .WithMany(x => x.BorrowedBooks)
                .HasForeignKey(x => x.BorrowerId);
        }
    }
}
