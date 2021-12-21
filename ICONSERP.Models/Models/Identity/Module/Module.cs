 
using ICONSERP.Models.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ICONSERP.Models.Models.Identity
{
    [Table("Module", Schema = "Identity")]

    public class Module : BaseModel
    {
        public string Code { get; set; }
        public string NameArabic { get; set; }
        public string NameEnglish { get; set; }
        public string Url { get; set; }
        public int Number { get; set; }
        public virtual ICollection<ModuleResource> ModuleResources { get; set; }
    }
}
