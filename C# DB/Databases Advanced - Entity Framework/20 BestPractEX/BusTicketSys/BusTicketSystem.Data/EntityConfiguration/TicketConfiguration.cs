using BusTicketSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusTicketSystem.Data.EntityConfiguration
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(x => x.TicketId);

            builder.Property(x => x.Price)
                .IsRequired();

            builder.Property(x => x.Seat)
                .IsRequired();

            builder.HasIndex(x => new {x.CustomerId, x.TripId }).IsUnique();
        }
    }
}
