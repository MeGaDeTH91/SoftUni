namespace MyBlog.Data.EntityConfiguration.ReviewsConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyBlog.Models.Reviews;

    public class ReviewConfig : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasAlternateKey(x => x.Title);

            builder.Property(x => x.Content)
                .IsRequired(true);

            builder.Property(x => x.PhotoURL)
                .IsRequired(true);

            builder.Property(x => x.HighLightVideoURL)
                .IsRequired(true);

            builder.Property(x => x.AdditionalInfoURL)
                .IsRequired(true);
        }
    }
}
