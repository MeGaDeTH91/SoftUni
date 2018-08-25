namespace MyBlog.Data.EntityConfiguration.FunConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyBlog.Models.Fun;

    public class JokeConfig : IEntityTypeConfiguration<Joke>
    {
        public void Configure(EntityTypeBuilder<Joke> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired(true);

            builder.Property(x => x.Content)
                .IsRequired(true);

            builder.Property(x => x.PhotoURL)
                .IsRequired(true);
        }
    }
}
