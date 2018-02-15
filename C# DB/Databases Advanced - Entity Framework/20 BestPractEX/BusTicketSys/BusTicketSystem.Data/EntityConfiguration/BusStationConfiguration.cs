using BusTicketSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusTicketSystem.Data.EntityConfiguration
{
    public class BusStationConfiguration : IEntityTypeConfiguration<BusStation>
    {
        public void Configure(EntityTypeBuilder<BusStation> builder)
        {
            builder.HasKey(x => x.BusStationId);

            builder.Property(x => x.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50);

            builder.HasMany(x => x.OriginTrips)
                .WithOne(x => x.OriginBusStation)
                .HasForeignKey(x => x.OriginBusStationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.DestinationTrips)
                .WithOne(x => x.DestinationBusStation)
                .HasForeignKey(x => x.DestinationBusStationId)
                .OnDelete(DeleteBehavior.Restrict);
                        
        }
    }
}
