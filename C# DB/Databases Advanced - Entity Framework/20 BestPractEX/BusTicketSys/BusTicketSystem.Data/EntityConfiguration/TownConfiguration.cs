using BusTicketSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusTicketSystem.Data.EntityConfiguration
{
    public class TownConfiguration : IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> builder)
        {
            builder.HasKey(x => x.TownId);

            builder.Property(x => x.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50);

            builder.Property(x => x.Country)
                .IsUnicode()
                .IsRequired()
                .HasMaxLength(25);

            builder.HasMany(x => x.Customers)
                .WithOne(x => x.HomeTown)
                .HasForeignKey(x => x.HomeTownId);

            builder.HasMany(x => x.BusStations)
                .WithOne(x => x.Town)
                .HasForeignKey(x => x.TownId);
        }
    }
}
