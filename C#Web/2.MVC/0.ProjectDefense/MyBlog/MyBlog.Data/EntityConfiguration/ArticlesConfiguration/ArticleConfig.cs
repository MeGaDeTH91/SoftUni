namespace MyBlog.Data.EntityConfiguration.ArticlesConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyBlog.Models.Articles;

    public class ArticleConfig : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasAlternateKey(x => x.Title);

            builder.Property(x => x.Content)
                .IsRequired(true);

            builder.Property(x => x.PhotoURL)
                .IsRequired(true);

            builder.Property(x => x.HighLightVideoURL)
                .IsRequired(true);
        }
    }
}
