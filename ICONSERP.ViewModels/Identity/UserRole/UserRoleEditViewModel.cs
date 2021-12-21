using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ICONSERP.ViewModels.Identity
{
    public class UserRoleEditViewModel
    {
        public long ID { get; set; }
        [Required]
        public long UserID { get; set; }
        [Required]
        public long RoleID { get; set; }
    }
}
