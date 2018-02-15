namespace Instagraph.Data.EntityConfiguration
{
    using Instagraph.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PostConfiguration : IEntityTypeConfiguration<Post>
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
