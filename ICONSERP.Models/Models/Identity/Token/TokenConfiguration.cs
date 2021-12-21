using ICONSERP.Models.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICONSERP.Models.Models.Identity
{
    public class TokenConfiguration : IEntityTypeConfiguration<Token>
    {
        public void Configure(EntityTypeBuilder<Token> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.Code).IsRequired();
            builder.Property(x => x.IP).IsRequired().HasMaxLength(500);
            builder.Property(x => x.UserAgent).IsRequired().HasMaxLength(500);
            builder.Property(x => x.ExpirationDate).IsRequired();
            builder.Property(x => x.LoggedOutDate).IsRequired(false);
            builder.Property(x => x.Active).IsRequired();
            builder.HasOne(x => x.TokenType).WithMany(x => x.Tokens).HasForeignKey(x => x.TokenTypeID).IsRequired(false);
            builder.HasOne(x => x.User).WithMany(x => x.Tokens).HasForeignKey(x => x.UserID).IsRequired();
        }
    }
}
