using BusTicketSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusTicketSystem.Data.EntityConfiguration
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(x => x.ReviewId);

            builder.Property(x => x.Content)
                .IsRequired()
                .HasColumnType("NVARCHAR(MAX)");

            builder.Property(x => x.Grade)
                .IsRequired();

            builder.Property(x => x.PublishDate)
                .HasColumnType("DATETIME2")
                .HasDefaultValueSql("GETDATE()");

            builder.HasOne(x => x.BusCompany)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.BusCompanyId);
        }
    }
}
