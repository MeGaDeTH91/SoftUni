namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using P03_FootballBetting.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class FootballBettingContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<User> Users { get; set; }

        public FootballBettingContext()
        {

        }

        public FootballBettingContext(DbContextOptions options)
            :base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Color>(entity =>
            {
                entity.HasKey(x => x.ColorId);
            });

            builder.Entity<Country>(entity =>
            {
                entity.HasKey(x => x.CountryId);
            });

            builder.Entity<Town>(entity =>
            {
                entity.HasKey(x => x.TownId);

                entity.Property(x => x.Name)
                .IsUnicode()
                .HasMaxLength(50);

                entity.HasOne(x => x.Country)
                .WithMany(x => x.Towns)
                .HasForeignKey(x => x.CountryId);
            });

            builder.Entity<Position>(entity => 
            {
                entity.HasKey(x => x.PositionId);

                entity.Property(x => x.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50);
            });

            builder.Entity<Player>(entity =>
            {
                entity.HasKey(x => x.PlayerId);

                entity.HasOne(x => x.Position)
                .WithMany(x => x.Players)
                .HasForeignKey(x => x.PositionId);

                entity.HasOne(x => x.Team)
                .WithMany(x => x.Players)
                .HasForeignKey(x => x.TeamId);
            });

            builder.Entity<Team>(entity =>
            {
                entity.HasKey(x => x.TeamId);

                entity.Property(x => x.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50);

                entity.HasOne(x => x.PrimaryKitColor)
                .WithMany(x => x.PrimaryKitTeams)
                .HasForeignKey(x => x.PrimaryKitColorId);

                entity.HasOne(x => x.SecondaryKitColor)
                .WithMany(t => t.SecondaryKitTeams)
                .HasForeignKey(f => f.SecondaryKitColorId);
            });

            builder.Entity<Game>(entity =>
            {
                entity.HasKey(x => x.GameId);

                entity.HasOne(x => x.HomeTeam)
                .WithMany(x => x.HomeGames)
                .HasForeignKey(x => x.HomeTeamId);

                entity.HasOne(x => x.AwayTeam)
                .WithMany(x => x.AwayGames)
                .HasForeignKey(x => x.AwayTeamId);
            });

            builder.Entity<PlayerStatistic>(entity =>
            {
                entity.HasKey(x => new { x.GameId, x.PlayerId });

                entity.HasOne(x => x.Game)
                .WithMany(x => x.PlayerStatistics)
                .HasForeignKey(x => x.GameId);

                entity.HasOne(x => x.Player)
                .WithMany(x => x.PlayerStatistics)
                .HasForeignKey(x => x.PlayerId);
            });

            builder.Entity<Bet>(entity =>
            {
                entity.HasKey(x => x.BetId);

                entity.HasOne(x => x.Game)
                .WithMany(x => x.Bets)
                .HasForeignKey(x => x.GameId);

                entity.HasOne(x => x.User)
                .WithMany(x => x.Bets)
                .HasForeignKey(x => x.UserId);
            });

            builder.Entity<User>(entity =>
            {
                entity.HasKey(x => x.UserId);

                entity.Property(x => x.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50);
            });
        }
    }
}
