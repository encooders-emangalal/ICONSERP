 
using ICONSERP.Models.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ICONSERP.Models.Models.Identity
{
    [Table("Permission", Schema = "Identity")]

    public class Permission : BaseModel
    {
        public string NameArabic { get; set; }
        public string NameEnglish { get; set; }
        public virtual ICollection<RoleModuleResourcePermission> RoleModuleResourcePermissions { get; set; }
    }
}
