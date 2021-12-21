using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ICONSERP.ViewModels.Identity
{
    public class RoleModuleResourcePermissionEditViewModel
    {
        public long ID { get; set; }
        [Required]
        public long RoleID { get; set; }
        [Required]
        public long ModuleResourceID { get; set; }
        [Required]
        public long PermissionID { get; set; }
    }
}
