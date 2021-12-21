 
using ICONSERP.Models.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ICONSERP.Models.Models.Identity
{
    [Table("UserRole", Schema = "Identity")]

    public class UserRole : BaseModel
    {
        public virtual User User { get; set; }
        public Guid UserID { get; set; }
        public virtual Role Role { get; set; }
        public Guid RoleID { get; set; }
    }
}
