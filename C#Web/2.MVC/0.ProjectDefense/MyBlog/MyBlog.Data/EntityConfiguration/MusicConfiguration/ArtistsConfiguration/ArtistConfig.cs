namespace MyBlog.Data.EntityConfiguration.MusicConfiguration.ArtistsConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyBlog.Models.Music.Artists;

    public class ArtistConfig : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasAlternateKey(x => x.FullName);

            builder.Property(x => x.Description)
                .IsRequired(true);

            builder.Property(x => x.PhotoURL)
                .IsRequired(true);

            builder.Property(x => x.HighLightVideoURL)
                .IsRequired(true);

            builder.Property(x => x.AdditionalInfoURL)
                .IsRequired(true);

            builder.HasMany(x => x.Songs)
                .WithOne(x => x.Artist)
                .HasForeignKey(x => x.ArtistId);
        }
    }
}
