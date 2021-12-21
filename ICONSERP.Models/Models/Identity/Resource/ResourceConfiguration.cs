using ICONSERP.Models.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICONSERP.Models.Models.Identity
{
    public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.Code).IsRequired().HasMaxLength(200);
            builder.Property(x => x.NameArabic).IsRequired().HasMaxLength(200);
            builder.Property(x => x.NameEnglish).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Url).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Number).IsRequired();
            builder.HasOne(x => x.ResourceType).WithMany(x => x.Resources).HasForeignKey(x => x.ResourceTypeID).IsRequired();
            builder.HasOne(x => x.ParentResource).WithMany(x => x.ChildResources).HasForeignKey(x => x.ParentResourceID).IsRequired(false);
        }
    }
}
