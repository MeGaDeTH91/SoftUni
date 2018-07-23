namespace MyLibrary.Data
{
    using Microsoft.EntityFrameworkCore;
    using MyLibrary.Data.EntityConfiguration;
    using MyLibrary.Models;

    public class BookLibraryDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Director> Directors { get; set; }

        public DbSet<Borrower> Borrowers { get; set; }

        public DbSet<BookBorrow> BookBorrows { get; set; }

        public DbSet<MovieBorrow> MovieBorrows { get; set; }

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
            modelBuilder.ApplyConfiguration(new MovieConfig());
            modelBuilder.ApplyConfiguration(new AuthorConfig());
            modelBuilder.ApplyConfiguration(new DirectorConfig());
            modelBuilder.ApplyConfiguration(new BorrowerConfig());
            modelBuilder.ApplyConfiguration(new BookBorrowConfig());
            modelBuilder.ApplyConfiguration(new MovieBorrowConfig());
        }
    }
}
