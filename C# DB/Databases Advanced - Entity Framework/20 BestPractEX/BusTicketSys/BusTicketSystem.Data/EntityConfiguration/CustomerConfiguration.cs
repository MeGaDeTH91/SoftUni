using BusTicketSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusTicketSystem.Data.EntityConfiguration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.CustomerId);

            builder.Property(x => x.FirstName)
                .IsUnicode(true)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(x => x.LastName)
                .IsUnicode(true)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(x => x.BirthDate)
                .IsRequired(false);

            builder.Property(x => x.Gender)
                .IsUnicode(false)
                .IsRequired(true)
                .HasMaxLength(15);

            builder.HasOne(x => x.BankAccount)
                .WithOne(x => x.Customer)
                .HasForeignKey<BankAccount>(x => x.CustomerId);

            builder.HasMany(x => x.Reviews)
                .WithOne(x => x.Customer)
                .HasForeignKey(x => x.CustomerId);

            builder.HasMany(x => x.Tickets)
                .WithOne(x => x.Customer)
                .HasForeignKey(x => x.CustomerId);
        }
    }
}
