namespace SimpleMvc.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SimpleMvc.Models;

    public class TubeConfig : IEntityTypeConfiguration<Tube>
    {
        public void Configure(EntityTypeBuilder<Tube> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired(true);

            builder.Property(x => x.Author)
                .IsRequired(true);

            builder.Property(x => x.YouTubeId)
                .IsRequired(true);

            builder.Property(x => x.UploaderId)
                .IsRequired(true);
        }
    }
}
