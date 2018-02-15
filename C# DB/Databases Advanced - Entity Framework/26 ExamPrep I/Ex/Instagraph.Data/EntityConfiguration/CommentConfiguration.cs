namespace Instagraph.Data.EntityConfiguration
{
    using Instagraph.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Content)
                .IsRequired(true)
                .HasMaxLength(250);

            builder.Property(x => x.PostId)
                .IsRequired(true);

            builder.Property(x => x.UserId)
                .IsRequired(true);
        }
    }
}
