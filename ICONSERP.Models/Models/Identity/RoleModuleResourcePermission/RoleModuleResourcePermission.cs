using ICONSERP.Models.BaseModel;
using ICONSERP.Models.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ICONSERPAPI.Models.Models.Identity
{
    [Table("RoleModuleResourcePermission", Schema = "Identity")]

    public class RoleModuleResourcePermission : BaseModel
    {
        public virtual Role Role { get; set; }
        public long RoleID { get; set; }
        public virtual ModuleResource ModuleResource { get; set; }
        public long ModuleResourceID { get; set; }
        public virtual Permission Permission { get; set; }
        public long PermissionID { get; set; }
    }
}
