using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICONSERP.Models.Models
{
    [Table("UserStatus", Schema = "Core")]
    public class UserStatus:BaseModel
    {
        [Required(ErrorMessage = "NameArabic is required")]
        public string NameArabic { get; set; }
        [Required(ErrorMessage = "NameEnglish is required")]
        public string NameEnglish { get; set; }
    }
}
