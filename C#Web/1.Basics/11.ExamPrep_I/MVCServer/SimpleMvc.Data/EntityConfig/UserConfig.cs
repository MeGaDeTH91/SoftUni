namespace SimpleMvc.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using SimpleMvc.Models;
    using System;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasAlternateKey(x => x.Username);
            builder.HasAlternateKey(x => x.Email);

            builder.Property(x => x.Username)
                .IsRequired(true);

            builder.Property(x => x.Email)
                .IsRequired(true);

            builder.Property(x => x.Password)
                .IsRequired(true);
        }
    }
}
