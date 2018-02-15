namespace ProductShop.Data
{
    using Microsoft.EntityFrameworkCore;
    using ProductShop.Data.EntityConfigs;
    using ProductShop.Models;

    public class ProductShopDbContext : DbContext
    {
        public ProductShopDbContext()
        {

        }

        public ProductShopDbContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryProduct> CategoriesProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ServerConfiguration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
