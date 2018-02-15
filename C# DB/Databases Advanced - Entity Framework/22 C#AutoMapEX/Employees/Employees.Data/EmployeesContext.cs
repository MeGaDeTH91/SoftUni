namespace Employees.Data
{
    using Employees.Data.EntityConfiguration;
    using Employees.Models;
    using Microsoft.EntityFrameworkCore;
    using System;

    public class EmployeesContext : DbContext
    {
        public EmployeesContext()
        {

        }

        public EmployeesContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ServerConfiguration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }

    }
}
