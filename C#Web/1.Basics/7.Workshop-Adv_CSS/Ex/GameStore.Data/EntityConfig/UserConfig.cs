namespace GameStore.Data.EntityConfig
{
    using GameStore.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Games)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            builder.HasAlternateKey(x => x.Email);
        }
    }
}
