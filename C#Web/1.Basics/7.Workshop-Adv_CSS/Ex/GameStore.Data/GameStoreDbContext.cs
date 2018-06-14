namespace GameStore.Data
{
    using GameStore.Data.EntityConfig;
    using GameStore.Models;
    using Microsoft.EntityFrameworkCore;

    public class GameStoreDbContext : DbContext
    {
        public GameStoreDbContext()
        {

        }

        public GameStoreDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<UserGame> UserGames { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(ServerConfig.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new GameConfig());
            modelBuilder.ApplyConfiguration(new UserGameConfig());
            modelBuilder.ApplyConfiguration(new ShoppingCartConfig());
        }
    }
}
