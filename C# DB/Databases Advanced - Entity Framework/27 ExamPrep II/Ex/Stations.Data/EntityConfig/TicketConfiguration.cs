namespace Stations.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Stations.Models;
    using System;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Price)
                .IsRequired(true);

            builder.Property(x => x.SeatingPlace)
                .IsRequired(true)
                .HasMaxLength(8);

            builder.Property(x => x.TripId)
                .IsRequired(true);

            builder.Property(x => x.CustomerCardId)
                .IsRequired(false);
        }
    }
}
