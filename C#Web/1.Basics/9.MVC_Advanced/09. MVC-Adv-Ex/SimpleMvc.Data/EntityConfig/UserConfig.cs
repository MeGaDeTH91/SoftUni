namespace SimpleMvc.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using SimpleMvc.Domain;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SimpleMvc.Domain.Common;

    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Notes)
                .WithOne(x => x.Owner)
                .HasForeignKey(x => x.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Username)
                .IsRequired(true)
                .HasMaxLength(ValidationConstants.UserConstraints.UsernameMaxLength);

            builder.Property(x => x.Password)
                .IsRequired(true)
                .HasMaxLength(ValidationConstants.UserConstraints.PasswordMaxLength);
        }
    }
}
