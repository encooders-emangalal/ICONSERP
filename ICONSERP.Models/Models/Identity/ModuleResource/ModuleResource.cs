using System.ComponentModel.DataAnnotations.Schema;
 
using ICONSERP.Models.Models.Identity;

namespace ICONSERP.Models.Models.Identity
{
    [Table("ModuleResource", Schema = "Identity")]

    public class ModuleResource : BaseModel
    {
        public virtual Module Module { get; set; }
        public long ModuleID { get; set; }
        public virtual Resource Resource { get; set; }
        public long ResourceID { get; set; }
        public int Number { get; set; }
        public virtual ICollection<RoleModuleResourcePermission> RoleModuleResourcePermissions { get; set; }
    }
}
