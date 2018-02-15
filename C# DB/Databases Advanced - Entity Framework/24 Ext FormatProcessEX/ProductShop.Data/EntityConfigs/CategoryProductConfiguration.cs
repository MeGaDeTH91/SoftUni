using Microsoft.EntityFrameworkCore;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProductShop.Data.EntityConfigs
{
    class CategoryProductConfiguration : IEntityTypeConfiguration<CategoryProduct>
    {
        public void Configure(EntityTypeBuilder<CategoryProduct> builder)
        {
            builder.HasKey(x => new { x.CategoryId, x.ProductId });

            builder.HasOne(x => x.Product)
                .WithMany(x => x.CategoriesProducts)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict); ;

            builder.HasOne(x => x.Category)
                .WithMany(x => x.CategoriesProducts)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict); ;
        }
    }
}
