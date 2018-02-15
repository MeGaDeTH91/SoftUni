using BusTicketSystem.Data.EntityConfiguration;
using BusTicketSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BusTicketSystem.Data
{
    public class BusTicketContext : DbContext
    {
        public BusTicketContext()
        {

        }

        public BusTicketContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<BusCompany> BusCompanies { get; set; }
        public DbSet<BusStation> BusStations { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<ArrivedTrip> ArrivedTrips { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ServerConfig.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BankAccountConfiguration());
            builder.ApplyConfiguration(new BusCompanyConfiguration());
            builder.ApplyConfiguration(new BusStationConfiguration());
            builder.ApplyConfiguration(new CustomerConfiguration());
            builder.ApplyConfiguration(new ReviewConfiguration());
            builder.ApplyConfiguration(new TicketConfiguration());
            builder.ApplyConfiguration(new TownConfiguration());
            builder.ApplyConfiguration(new TownConfiguration());
            builder.ApplyConfiguration(new ArrivedTripConfiguration());
        }
    }
}
