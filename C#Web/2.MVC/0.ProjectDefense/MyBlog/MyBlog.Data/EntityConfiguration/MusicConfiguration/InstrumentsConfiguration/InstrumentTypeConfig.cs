namespace MyBlog.Data.EntityConfiguration.MusicConfiguration.InstrumentsConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyBlog.Models.Music.Instruments;

    public class InstrumentTypeConfig : IEntityTypeConfiguration<InstrumentType>
    {
        public void Configure(EntityTypeBuilder<InstrumentType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasAlternateKey(x => x.TypeName);

            builder.HasMany(x => x.Instruments)
                .WithOne(x => x.InstrumentType)
                .HasForeignKey(x => x.InstrumentTypeId);
        }
    }
}
