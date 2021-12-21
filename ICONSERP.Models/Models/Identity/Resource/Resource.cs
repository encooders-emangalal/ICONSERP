 
using ICONSERP.Models.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ICONSERP.Models.Models.Identity
{
    [Table("Resource", Schema = "Identity")]

    public class Resource : BaseModel
    {
        public virtual ResourceType ResourceType { get; set; }
        public Guid ResourceTypeID { get; set; }
        public virtual Resource ParentResource { get; set; }
        public Guid? ParentResourceID { get; set; }
        public string Code { get; set; }
        public string NameArabic { get; set; }
        public string NameEnglish { get; set; }
        public string Url { get; set; }
        public int Number { get; set; }
        public virtual ICollection<ModuleResource> ModuleResources { get; set; }
        public virtual ICollection<Resource> ChildResources { get; set; }
    }
}
