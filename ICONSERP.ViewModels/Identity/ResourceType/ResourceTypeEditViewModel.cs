using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ICONSERP.ViewModels.Identity
{
    public class ResourceTypeEditViewModel
    {
        public long ID { get; set; }
        [Required]
        public string NameArabic { get; set; }
        [Required]
        public string NameEnglish { get; set; }
    }
}
