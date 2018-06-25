namespace SimpleMvc.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using SimpleMvc.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class KittenConfig : IEntityTypeConfiguration<Kitten>
    {
        public void Configure(EntityTypeBuilder<Kitten> builder)
        {
            builder.HasKey(x => x.Id);
            

            builder.Property(x => x.Name)
                .IsRequired(true);

            builder.Property(x => x.Age)
                .IsRequired(true);
        }
    }
}
