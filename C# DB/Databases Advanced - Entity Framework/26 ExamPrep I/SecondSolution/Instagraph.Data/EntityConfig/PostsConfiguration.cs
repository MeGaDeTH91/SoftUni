namespace Instagraph.Data.EntityConfig
{
    using Instagraph.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PostsConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Caption)
                .IsRequired(true);

            builder.Property(x => x.UserId)
                .IsRequired(true);

            builder.Property(x => x.PictureId)
                .IsRequired(true);

            builder.HasMany(x => x.Comments)
                .WithOne(x => x.Post)
                .HasForeignKey(x => x.PostId);
        }
    }
}
