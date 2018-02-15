namespace TeamBuilder.Data
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using TeamBuilder.Data.EntityConfiguration;
    using TeamBuilder.Models;

    public class TeamBuilderContext : DbContext
    {
        public TeamBuilderContext(){ }

        public TeamBuilderContext(DbContextOptions options)
            :base(options){ }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventTeam> EventTeams { get; set; }
        public DbSet<Invitation> Invitations { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserTeam> UserTeams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ServerConfiguration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            modelBuilder.ApplyConfiguration(new EventTeamConfiguration());
            modelBuilder.ApplyConfiguration(new InvitationConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserTeamConfiguration());
        }
    }
}
