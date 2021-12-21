using ICONSERPAPI.Models.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICONSERP.Models.Models.Identity
{
    public class RoleModuleResourcePermissionConfiguration : IEntityTypeConfiguration<RoleModuleResourcePermission>
    {
        public void Configure(EntityTypeBuilder<RoleModuleResourcePermission> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.HasOne(x => x.Role).WithMany(x => x.RoleModuleResourcePermissions).HasForeignKey(x => x.RoleID).IsRequired();
            builder.HasOne(x => x.ModuleResource).WithMany(x => x.RoleModuleResourcePermissions).HasForeignKey(x => x.ModuleResourceID).IsRequired();
            builder.HasOne(x => x.Permission).WithMany(x => x.RoleModuleResourcePermissions).HasForeignKey(x => x.PermissionID).IsRequired();
        }
    }
}
