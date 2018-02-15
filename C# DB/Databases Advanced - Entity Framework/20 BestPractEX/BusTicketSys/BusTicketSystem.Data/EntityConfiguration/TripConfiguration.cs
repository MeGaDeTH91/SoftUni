using BusTicketSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusTicketSystem.Data.EntityConfiguration
{
    public class TripConfiguration : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.HasKey(x => x.TripId);

            builder.Property(x => x.DepartureTime)
                .IsRequired();

            builder.Property(x => x.ArrivalTime)
                .IsRequired();

            builder.Property(x => x.Status)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.OriginBusStationId)
                .IsRequired();

            builder.Property(x => x.DestinationBusStationId)
                .IsRequired();

            builder.HasMany(x => x.Tickets)
                .WithOne(x => x.Trip)
                .HasForeignKey(x => x.TripId);
        }
    }
}
