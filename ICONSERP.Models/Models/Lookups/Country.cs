using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICONSERP.Models.Models
{
    [Table("Country", Schema = "Core")]
    public class Country : BaseModel
    {
        [Required(ErrorMessage = "Code is required")]
        public string Code { get; set; }
        [Required(ErrorMessage = "NameArabic is required")]
        public string NameArabic { get; set; }
        [Required(ErrorMessage = "NameEnglish is required")]
        public string NameEnglish { get; set; }
    }
}
