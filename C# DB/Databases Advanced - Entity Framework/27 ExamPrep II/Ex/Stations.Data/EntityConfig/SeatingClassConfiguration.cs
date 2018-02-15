namespace Stations.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Stations.Models;

    public class SeatingClassConfiguration : IEntityTypeConfiguration<SeatingClass>
    {
        public void Configure(EntityTypeBuilder<SeatingClass> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasAlternateKey(x => x.Name);
            builder.HasAlternateKey(x => x.Abbreviation);

            builder.Property(x => x.Name)
                .IsRequired(true)
                .HasMaxLength(30);

            builder.Property(x => x.Abbreviation)
                .IsRequired(true)
                .HasMaxLength(2);

            builder.HasMany(x => x.TrainSeats)
                .WithOne(x => x.SeatingClass)
                .HasForeignKey(x => x.SeatingClassId);
        }
    }
}
