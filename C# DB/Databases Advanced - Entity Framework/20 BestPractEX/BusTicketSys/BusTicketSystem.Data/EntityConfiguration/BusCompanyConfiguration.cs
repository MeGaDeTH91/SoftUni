using BusTicketSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusTicketSystem.Data.EntityConfiguration
{
    public class BusCompanyConfiguration : IEntityTypeConfiguration<BusCompany>
    {
        public void Configure(EntityTypeBuilder<BusCompany> builder)
        {
            builder.HasKey(x => x.BusCompanyId);

            builder.Property(x => x.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50);

            builder.Property(x => x.Nationality)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50);

            builder.HasMany(x => x.Trips)
                .WithOne(x => x.BusCompany)
                .HasForeignKey(x => x.BusCompanyId);
        }
    }
}
