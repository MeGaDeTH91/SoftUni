namespace SimpleMvc.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SimpleMvc.Models;

    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Username)
                .IsRequired(true);

            builder.Property(x => x.Password)
                .IsRequired(true);

            builder.Property(x => x.Email)
                .IsRequired(true);

            builder.HasMany(x => x.Tubes)
                .WithOne(x => x.Uploader)
                .HasForeignKey(x => x.UploaderId);
        }
    }
}
