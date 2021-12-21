 
using ICONSERP.Models.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ICONSERP.Models.Models.Identity
{
    [Table("RoleModuleResourcePermission", Schema = "Identity")]

    public class RoleModuleResourcePermission : BaseModel
    {
        public virtual Role Role { get; set; }
        public Guid RoleID { get; set; }
        public virtual ModuleResource ModuleResource { get; set; }
        public Guid ModuleResourceID { get; set; }
        public virtual Permission Permission { get; set; }
        public Guid PermissionID { get; set; }
    }
}
