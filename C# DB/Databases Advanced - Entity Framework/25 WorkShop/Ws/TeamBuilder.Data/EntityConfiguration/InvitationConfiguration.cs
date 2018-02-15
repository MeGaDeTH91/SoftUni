using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TeamBuilder.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TeamBuilder.Data.EntityConfiguration
{
    public class InvitationConfiguration : IEntityTypeConfiguration<Invitation>
    {
        public void Configure(EntityTypeBuilder<Invitation> builder)
        {
            builder.HasKey(x => x.InvitationId);
        }
    }
}
