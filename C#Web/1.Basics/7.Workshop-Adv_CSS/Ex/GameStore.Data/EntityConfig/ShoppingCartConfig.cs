namespace GameStore.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using GameStore.Models;

    public class ShoppingCartConfig : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.HasKey(x => new { x.UserId, x.GameId });

            builder.HasOne(x => x.User)
                .WithMany(x => x.ShoppingCart)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Game)
                .WithMany(x => x.ShoppingCartUsers)
                .HasForeignKey(x => x.GameId);
        }
    }
}
