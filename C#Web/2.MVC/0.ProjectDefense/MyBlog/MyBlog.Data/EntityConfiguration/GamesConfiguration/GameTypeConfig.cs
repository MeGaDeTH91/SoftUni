namespace MyBlog.Data.EntityConfiguration.GamesConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyBlog.Models.Games;

    public class GameTypeConfig : IEntityTypeConfiguration<GameType>
    {
        public void Configure(EntityTypeBuilder<GameType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasAlternateKey(x => x.GameTypeName);

            builder.HasMany(x => x.Games)
                .WithOne(x => x.GameType)
                .HasForeignKey(x => x.GameTypeId);
        }
    }
}
