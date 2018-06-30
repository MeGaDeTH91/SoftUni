namespace SimpleMvc.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SimpleMvc.Models;

    public class BreedConfig : IEntityTypeConfiguration<Breed>
    {
        public void Configure(EntityTypeBuilder<Breed> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired(true);

            builder.HasAlternateKey(x => x.Name);

            builder.HasMany(x => x.Kittens)
                .WithOne(x => x.Breed)
                .HasForeignKey(x => x.BreedId);
        }
    }
}
