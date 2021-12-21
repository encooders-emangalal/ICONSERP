using ICONSERP.Models.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICONSERP.Models.Models.Identity
{
    public class TokenLogConfiguration : IEntityTypeConfiguration<TokenLog>
    {
        public void Configure(EntityTypeBuilder<TokenLog> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.IP).HasMaxLength(200);
            builder.Property(x => x.UserAgent);
            builder.Property(x => x.Data);
            builder.Property(x => x.OtherInfo);
            builder.Property(x => x.URL);
            builder.Property(x => x.ErrorInfo);
            builder.Property(x => x.Message);
            builder.Property(x => x.MessageTemplate);
            builder.Property(x => x.Level);
            builder.Property(x => x.TimeStamp).IsRequired();
            builder.Property(x => x.Exception);
            builder.Property(x => x.Properties);
            builder.HasOne(x => x.LogType).WithMany(x => x.TokenLogs).HasForeignKey(x => x.LogTypeID).IsRequired();
            builder.HasOne(x => x.Token).WithMany(x => x.TokenLogs).HasForeignKey(x => x.TokenID);
        }
    }
}
