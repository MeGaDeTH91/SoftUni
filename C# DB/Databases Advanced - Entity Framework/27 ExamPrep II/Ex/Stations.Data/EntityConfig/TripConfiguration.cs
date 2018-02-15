namespace Stations.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Stations.Models;

    public class TripConfiguration : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.OriginStationId)
                .IsRequired(true);

            builder.Property(x => x.DestinationStationId)
                .IsRequired(true);

            builder.Property(x => x.DepartureTime)
                .IsRequired(true);

            builder.Property(x => x.ArrivalTime)
                .IsRequired(true);

            builder.Property(x => x.TrainId)
                .IsRequired(true);

            builder.Property(x => x.Status)
                .HasDefaultValue(TripStatus.OnTime);

            builder.Property(x => x.TimeDifference)
                .IsRequired(false);

            builder.HasMany(x => x.Tickets)
                .WithOne(x => x.Trip)
                .HasForeignKey(x => x.TripId);
        }
    }
}
