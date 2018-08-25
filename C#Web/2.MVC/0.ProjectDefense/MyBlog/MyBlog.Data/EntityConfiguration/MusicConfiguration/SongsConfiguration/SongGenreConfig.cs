namespace MyBlog.Data.EntityConfiguration.MusicConfiguration.SongsConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyBlog.Models.Music.Songs;

    public class SongGenreConfig : IEntityTypeConfiguration<SongGenre>
    {
        public void Configure(EntityTypeBuilder<SongGenre> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasAlternateKey(x => x.GenreName);

            builder.HasMany(x => x.Songs)
                .WithOne(x => x.SongGenre)
                .HasForeignKey(x => x.SongGenreId);
        }
    }
}
