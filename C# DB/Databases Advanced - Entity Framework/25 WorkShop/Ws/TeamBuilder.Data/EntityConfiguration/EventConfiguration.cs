using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TeamBuilder.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TeamBuilder.Data.EntityConfiguration
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(x => x.EventId);

            builder.Property(x => x.Name)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(25);

            builder.Property(x => x.Description)
                .IsRequired(false)
                .IsUnicode(true)
                .HasMaxLength(250);
        }
    }
}
