using BusTicketSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusTicketSystem.Data.EntityConfiguration
{
    public class ArrivedTripConfiguration : IEntityTypeConfiguration<ArrivedTrip>
    {
        public void Configure(EntityTypeBuilder<ArrivedTrip> builder)
        {
            builder.HasKey(x => x.ArrivedTripId);

            builder.HasOne(x => x.ArriveOriginBusStation)
                .WithMany(x => x.ArrivedOriginTrips)
                .HasForeignKey(x => x.ArriveOriginBusStationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ArriveDestinationBusStation)
                .WithMany(x => x.ArrivedDestinationTrips)
                .HasForeignKey(x => x.ArriveDestinationBusStationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
