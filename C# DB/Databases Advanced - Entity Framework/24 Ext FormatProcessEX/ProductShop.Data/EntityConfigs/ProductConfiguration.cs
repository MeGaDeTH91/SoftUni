using Microsoft.EntityFrameworkCore;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProductShop.Data.EntityConfigs
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.ProductId);

            builder.Property(x => x.Name)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(250);

            builder.Property(x => x.Price)
                .IsRequired(true);

            builder.Property(x => x.BuyerId)
                .IsRequired(false);

            builder.Property(x => x.SellerId)
                .IsRequired(true);

            builder.HasOne(x => x.Buyer)
                .WithMany(x => x.BoughtProducts)
                .HasForeignKey(x => x.BuyerId);

            builder.HasOne(x => x.Seller)
                .WithMany(x => x.SoldProducts)
                .HasForeignKey(x => x.SellerId);                        
        }
    }
}
