namespace MyBlog.Data.EntityConfiguration.MusicConfiguration.ArtistsConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyBlog.Models.Music.Artists;

    public class ArtistTypeConfig : IEntityTypeConfiguration<ArtistType>
    {
        public void Configure(EntityTypeBuilder<ArtistType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasAlternateKey(x => x.ArtistTypeName);

            builder.HasMany(x => x.Artists)
                .WithOne(x => x.ArtistType)
                .HasForeignKey(x => x.ArtistTypeId);
        }
    }
}
