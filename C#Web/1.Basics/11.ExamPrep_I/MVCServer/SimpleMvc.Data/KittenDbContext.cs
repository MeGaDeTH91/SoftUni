namespace SimpleMvc.Data
{
    using Microsoft.EntityFrameworkCore;
    using SimpleMvc.Data.EntityConfig;
    using SimpleMvc.Data.ServerConfigFolder;
    using SimpleMvc.Models;

    public class KittenDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Kitten> Kittens { get; set; }

        public DbSet<Breed> Breeds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ServerConfig.ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new KittenConfig());
            modelBuilder.ApplyConfiguration(new BreedConfig());
        }
    }
}
