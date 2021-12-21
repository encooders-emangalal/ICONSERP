using ICONSERPAPI.Models.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICONSERP.Models.Models.Identity
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).ValueGeneratedNever();
            builder.Property(x => x.NameArabic).IsRequired().HasMaxLength(200);
            builder.Property(x => x.NameEnglish).IsRequired().HasMaxLength(200);
        }
    }
}
