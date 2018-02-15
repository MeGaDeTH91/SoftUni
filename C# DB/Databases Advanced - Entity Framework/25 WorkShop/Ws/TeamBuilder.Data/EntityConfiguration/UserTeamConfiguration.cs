using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TeamBuilder.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TeamBuilder.Data.EntityConfiguration
{
    public class UserTeamConfiguration : IEntityTypeConfiguration<UserTeam>
    {
        public void Configure(EntityTypeBuilder<UserTeam> builder)
        {
            builder.HasKey(x => new { x.UserId, x.TeamId });

            builder.HasOne(x => x.User)
                .WithMany(x => x.UserTeams)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Team)
                .WithMany(x => x.UserTeams)
                .HasForeignKey(x => x.TeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
