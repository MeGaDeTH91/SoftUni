namespace FastFood.Data.EntityConfiguration
{
    using FastFood.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PositionsConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasAlternateKey(x => x.Name);

            builder.Property(x => x.Name)
                .IsRequired(true)
                .HasMaxLength(30);

            builder.HasMany(x => x.Employees)
                .WithOne(x => x.Position)
                .HasForeignKey(x => x.PositionId);
        }
    }
}
