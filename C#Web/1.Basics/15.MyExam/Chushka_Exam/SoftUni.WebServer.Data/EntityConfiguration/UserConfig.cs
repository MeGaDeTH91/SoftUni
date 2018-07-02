namespace SoftUni.WebServer.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SoftUni.WebServer.Models;

    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasAlternateKey(x => x.Username);
            builder.HasAlternateKey(x => x.Email);

            builder.Property(x => x.Username)
                .IsRequired(true);

            builder.Property(x => x.Password)
                .IsRequired(true);

            builder.Property(x => x.FullName)
                .IsRequired(true);

            builder.Property(x => x.Email)
                .IsRequired(true);

            builder.HasMany(x => x.Orders)
                .WithOne(x => x.Client)
                .HasForeignKey(x => x.ClientId);
        }
    }
}
