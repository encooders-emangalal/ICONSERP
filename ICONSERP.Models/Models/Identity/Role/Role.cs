using ICONSERP.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ICONSERPAPI.Models.Models.Identity
{
    [Table("Role", Schema = "Identity")]

    public class Role : BaseModel
    {
        public string Code { get; set; }
        public string NameArabic { get; set; }
        public string NameEnglish { get; set; }
        public virtual ICollection<RoleModuleResourcePermission> RoleModuleResourcePermissions { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
