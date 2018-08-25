namespace MyBlog.Data.EntityConfiguration.ArticlesConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyBlog.Models.Articles;

    public class ArticleCategoryConfig : IEntityTypeConfiguration<ArticleCategory>
    {
        public void Configure(EntityTypeBuilder<ArticleCategory> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasAlternateKey(x => x.CategoryName);

            builder.HasMany(x => x.Articles)
                .WithOne(x => x.ArticleCategory)
                .HasForeignKey(x => x.ArticleCategoryId);
        }
    }
}
