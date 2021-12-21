using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICONSERP.Models.Models.Lookups
{
    [Table("BillingCycle", Schema = "Core")]

    public class BillingCycle:BaseModel
    {
        [Required(ErrorMessage = "NameArabic is required")]
        public string NameArabic { get; set; }
        [Required(ErrorMessage = "NameEnglish is required")]
        public string NameEnglish { get; set; }

        public int DisplayOrder { get; set; }
    }
}
