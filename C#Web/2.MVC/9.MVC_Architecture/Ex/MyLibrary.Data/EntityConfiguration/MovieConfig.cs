namespace MyLibrary.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyLibrary.Models;

    public class MovieConfig : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Director)
                .WithMany(x => x.Movies)
                .HasForeignKey(x => x.DirectorId);

            builder.Property(x => x.Title)
                .IsRequired(true);

            builder.Property(x => x.Description)
                .IsRequired(false);

            builder.Property(x => x.PosterImage)
                .IsRequired(false);
        }
    }
}
