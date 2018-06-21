namespace SimpleMvc.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using SimpleMvc.Domain;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SimpleMvc.Domain.Common;

    public class NoteConfig : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired(true)
                .HasMaxLength(ValidationConstants.NoteConstraints.TitleMaxLength);

            builder.Property(x => x.Content)
                .IsRequired(true);
        }
    }
}
