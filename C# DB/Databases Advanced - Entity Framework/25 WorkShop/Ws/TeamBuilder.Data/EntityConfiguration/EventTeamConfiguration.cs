using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TeamBuilder.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TeamBuilder.Data.EntityConfiguration
{
    public class EventTeamConfiguration : IEntityTypeConfiguration<EventTeam>
    {
        public void Configure(EntityTypeBuilder<EventTeam> builder)
        {
            builder.HasKey(x => new { x.EventId, x.TeamId });

            builder.HasOne(x => x.Event)
                .WithMany(x => x.ParticipatingEventTeams)
                .HasForeignKey(x => x.EventId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Team)
                .WithMany(x => x.EventTeams)
                .HasForeignKey(x => x.TeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
