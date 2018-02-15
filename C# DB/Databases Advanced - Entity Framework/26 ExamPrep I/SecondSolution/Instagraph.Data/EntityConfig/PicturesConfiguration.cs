namespace Instagraph.Data.EntityConfig
{
    using Instagraph.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PicturesConfiguration : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Path)
                .IsRequired(true);

            builder.Property(x => x.Size)
                .IsRequired(true);

            builder.HasMany(x => x.Posts)
                .WithOne(x => x.Picture)
                .HasForeignKey(x => x.PictureId);

            builder.HasMany(x => x.Users)
                .WithOne(x => x.ProfilePicture)
                .HasForeignKey(x => x.ProfilePictureId);
        }
    }
}
