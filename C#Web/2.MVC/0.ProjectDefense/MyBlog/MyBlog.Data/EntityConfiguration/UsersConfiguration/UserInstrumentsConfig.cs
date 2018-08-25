namespace MyBlog.Data.EntityConfiguration.UsersConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyBlog.Models.Users;

    public class UserInstrumentsConfig : IEntityTypeConfiguration<UserInstruments>
    {
        public void Configure(EntityTypeBuilder<UserInstruments> builder)
        {
            builder.HasKey(x => new { x.InstrumentId, x.UserId });

            builder.HasOne(x => x.User)
                .WithMany(x => x.FavouriteInstruments)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Instrument)
                .WithMany(x => x.AddedToFavoritesBy)
                .HasForeignKey(x => x.InstrumentId);

            builder.Property(x => x.AddedToFavouritesOn)
                .IsRequired(true);
        }
    }
}
