namespace FDMC.Data
{
    using FDMC.Data.EntityConfiguration;
    using FDMC.Models;
    using Microsoft.EntityFrameworkCore;
    

    public class FDMCDbContext : DbContext
    {
        public DbSet<Cat> Cats { get; set; }

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
            modelBuilder.ApplyConfiguration(new CatEntityConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
