using FastFood.Data.EntityConfiguration;
using FastFood.Models;
using Microsoft.EntityFrameworkCore;

namespace FastFood.Data
{
	public class FastFoodDbContext : DbContext
	{
		public FastFoodDbContext()
		{
		}

		public FastFoodDbContext(DbContextOptions options)
			: base(options)
		{
		}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
		{
			if (!builder.IsConfigured)
			{
				builder.UseSqlServer(Configuration.ConnectionString);
			}
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
            builder.ApplyConfiguration(new CategoriesConfiguration());
            builder.ApplyConfiguration(new EmployeesConfiguration());
            builder.ApplyConfiguration(new ItemsConfiguration());
            builder.ApplyConfiguration(new OrderItemsConfiguration());
            builder.ApplyConfiguration(new OrdersConfiguration());
            builder.ApplyConfiguration(new PositionsConfiguration());
        }
	}
}