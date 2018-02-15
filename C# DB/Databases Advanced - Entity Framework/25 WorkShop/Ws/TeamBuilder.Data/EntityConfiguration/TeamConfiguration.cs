using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TeamBuilder.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TeamBuilder.Data.EntityConfiguration
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(x => x.TeamId);

            builder.HasAlternateKey(x => x.Name);

            builder.Property(x => x.Name)
                .IsRequired(true)
                .IsUnicode(false)
                .HasMaxLength(25);

            builder.Property(x => x.Description)
                .HasMaxLength(32);

            builder.Property(x => x.Acronym)
                .IsRequired(true)
                .HasMaxLength(3);

            builder.HasMany(x => x.Invitations)
                .WithOne(x => x.Team)
                .HasForeignKey(x => x.TeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
