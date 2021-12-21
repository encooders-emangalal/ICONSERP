using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ICONSERP.ViewModels.Identity
{
    public class RoleModuleResourcePermissionEditViewModel
    {
        public Guid ID { get; set; }
        [Required]
        public Guid RoleID { get; set; }
        [Required]
        public Guid ModuleResourceID { get; set; }
        [Required]
        public Guid PermissionID { get; set; }
    }
}
