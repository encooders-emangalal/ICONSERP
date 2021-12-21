using ICONSERPAPI.Models.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICONSERP.Models.Models.Identity
{
    public class ModuleResourceConfiguration : IEntityTypeConfiguration<ModuleResource>
    {
        public void Configure(EntityTypeBuilder<ModuleResource> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.Number).IsRequired();
            builder.HasOne(x => x.Module).WithMany(x => x.ModuleResources).HasForeignKey(x => x.ModuleID).IsRequired();
            builder.HasOne(x => x.Resource).WithMany(x => x.ModuleResources).HasForeignKey(x => x.ResourceID).IsRequired();
        }
    }
}
