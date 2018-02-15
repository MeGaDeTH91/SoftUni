namespace Stations.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Stations.Models;

    public class TrainConfiguration : IEntityTypeConfiguration<Train>
    {
        public void Configure(EntityTypeBuilder<Train> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasAlternateKey(x => x.TrainNumber);

            builder.Property(x => x.TrainNumber)
                .IsRequired(true)
                .HasMaxLength(10);

            builder.HasMany(x => x.Trips)
                .WithOne(x => x.Train)
                .HasForeignKey(x => x.TrainId);

            builder.HasMany(x => x.TrainSeats)
                .WithOne(x => x.Train)
                .HasForeignKey(x => x.TrainId);
        }
    }
}
