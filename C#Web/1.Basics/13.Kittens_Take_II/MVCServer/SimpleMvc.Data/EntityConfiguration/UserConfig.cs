namespace SimpleMvc.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SimpleMvc.Models;

    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasAlternateKey(x => x.Username);

            builder.HasAlternateKey(x => x.Email);

            builder.Property(x => x.Password)
                .IsRequired(true);
        }
    }
}
