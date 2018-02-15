using Employees.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employees.Data.EntityConfiguration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.EmployeeId);

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(x => x.Address)
                .HasMaxLength(250);
        }
    }
}
