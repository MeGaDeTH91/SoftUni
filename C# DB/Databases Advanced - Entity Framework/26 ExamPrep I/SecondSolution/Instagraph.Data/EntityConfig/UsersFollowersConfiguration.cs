namespace Instagraph.Data.EntityConfig
{
    using Instagraph.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UsersFollowersConfiguration : IEntityTypeConfiguration<UserFollower>
    {
        public void Configure(EntityTypeBuilder<UserFollower> builder)
        {
            builder.HasKey(x => new { x.UserId, x.FollowerId});
        }
    }
}
