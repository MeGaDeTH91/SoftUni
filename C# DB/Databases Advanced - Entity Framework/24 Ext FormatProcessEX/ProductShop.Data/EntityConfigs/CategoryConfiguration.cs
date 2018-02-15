using Microsoft.EntityFrameworkCore;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProductShop.Data.EntityConfigs
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.CategoryId);

            builder.Property(x => x.Name)
                .IsUnicode(true)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
