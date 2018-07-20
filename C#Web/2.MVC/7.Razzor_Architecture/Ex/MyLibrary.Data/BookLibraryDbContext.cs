namespace MyLibrary.Data
{
    using Microsoft.EntityFrameworkCore;
    using MyLibrary.Data.EntityConfiguration;
    using MyLibrary.Models;

    public class BookLibraryDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Borrower> Borrowers { get; set; }

        public DbSet<BookBorrow> BookBorrows { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ServerConfig.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BookConfig());
            modelBuilder.ApplyConfiguration(new AuthorConfig());
            modelBuilder.ApplyConfiguration(new BorrowerConfig());
            modelBuilder.ApplyConfiguration(new BookBorrowConfig());
        }
    }
}
