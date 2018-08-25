namespace MyBlog.Data.EntityConfiguration.MusicConfiguration.InstrumentsConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyBlog.Models.Music.Instruments;

    public class InstrumentConfig : IEntityTypeConfiguration<Instrument>
    {
        public void Configure(EntityTypeBuilder<Instrument> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasAlternateKey(x => x.ModelName);

            builder.Property(x => x.Description)
                .IsRequired(true);

            builder.Property(x => x.PhotoURL)
                .IsRequired(true);

            builder.Property(x => x.HighLightVideoURL)
                .IsRequired(true);

            builder.Property(x => x.AdditionalInfoURL)
                .IsRequired(true);
        }
    }
}
