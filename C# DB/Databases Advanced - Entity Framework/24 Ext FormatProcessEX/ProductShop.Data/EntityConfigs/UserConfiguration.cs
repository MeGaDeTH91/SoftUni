using Microsoft.EntityFrameworkCore;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProductShop.Data.EntityConfigs
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.UserId);

            builder.Property(x => x.FirstName)
                .IsRequired(false)
                .IsUnicode()
                .HasMaxLength(50);

            builder.Property(x => x.LastName)
                .IsRequired(true)
                .IsUnicode()
                .HasMaxLength(50);

            builder.Property(x => x.Age)
                .IsRequired(false);
        }
    }
}
