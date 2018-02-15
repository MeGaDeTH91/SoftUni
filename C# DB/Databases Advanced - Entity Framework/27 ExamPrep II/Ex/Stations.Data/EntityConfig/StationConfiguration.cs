namespace Stations.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Stations.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class StationConfiguration : IEntityTypeConfiguration<Station>
    {
        public void Configure(EntityTypeBuilder<Station> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasAlternateKey(x => x.Name);

            builder.Property(x => x.Name)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(x => x.Town)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.HasMany(x => x.TripsTo)
                .WithOne(x => x.DestinationStation)
                .HasForeignKey(x => x.DestinationStationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.TripsFrom)
                .WithOne(x => x.OriginStation)
                .HasForeignKey(x => x.OriginStationId)
                .OnDelete(DeleteBehavior.Restrict); ;
        }
    }
}
