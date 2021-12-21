using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ICONSERP.ViewModels.Identity
{
    public class ResourceEditViewModel
    {
        public long ID { get; set; }
        [Required]
        public long ResourceTypeID { get; set; }
        public long? ParentResourceID { get; set; }
        public string Code { get; set; }
        [Required]
        public string NameArabic { get; set; }
        [Required]
        public string NameEnglish { get; set; }
        [Required]
        public string Url { get; set; }
        public long Number { get; set; }
    }
}
