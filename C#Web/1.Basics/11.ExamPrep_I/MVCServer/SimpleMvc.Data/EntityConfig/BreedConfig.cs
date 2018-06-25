namespace SimpleMvc.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using SimpleMvc.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BreedConfig : IEntityTypeConfiguration<Breed>
    {
        public void Configure(EntityTypeBuilder<Breed> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired(true);

            builder.HasMany(x => x.Kittens)
                .WithOne(x => x.Breed)
                .HasForeignKey(x => x.BreedId);
        }
    }
}
