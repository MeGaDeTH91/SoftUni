namespace Stations.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Stations.Models;

    public class TrainSeatConfiguration : IEntityTypeConfiguration<TrainSeat>
    {
        public void Configure(EntityTypeBuilder<TrainSeat> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.SeatingClassId)
                .IsRequired(true);

            builder.Property(x => x.TrainId)
                .IsRequired(true);

            builder.Property(x => x.Quantity)
                .IsRequired(true);
        }
    }
}
