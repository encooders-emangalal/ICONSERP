using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ICONSERP.ViewModels.Identity
{
    public class ModuleResourceEditViewModel
    {
        public long ID { get; set; }
        [Required]
        public long ModuleID { get; set; }
        [Required]
        public long ResourceID { get; set; }
        [Required]
        public int Number { get; set; }
    }
}
