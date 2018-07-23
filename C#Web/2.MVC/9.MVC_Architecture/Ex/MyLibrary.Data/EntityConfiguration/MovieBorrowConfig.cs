namespace MyLibrary.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyLibrary.Models;

    public class MovieBorrowConfig : IEntityTypeConfiguration<MovieBorrow>
    {
        public void Configure(EntityTypeBuilder<MovieBorrow> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Movie)
                .WithMany(x => x.Borrowers)
                .HasForeignKey(x => x.MovieId);

            builder.HasOne(x => x.Borrower)
                .WithMany(x => x.BorrowedMovies)
                .HasForeignKey(x => x.BorrowerId);
        }
    }
}
