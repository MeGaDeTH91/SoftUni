namespace MyBlog.Data.EntityConfiguration.ReviewsConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyBlog.Models.Reviews;

    public class ReviewTypeConfig : IEntityTypeConfiguration<ReviewType>
    {
        public void Configure(EntityTypeBuilder<ReviewType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasAlternateKey(x => x.ReviewTypeName);

            builder.HasMany(x => x.Reviews)
                .WithOne(x => x.ReviewType)
                .HasForeignKey(x => x.ReviewTypeId);
        }
    }
}
