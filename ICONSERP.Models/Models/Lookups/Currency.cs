using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICONSERP.Models.Models
{
    [Table("Currency", Schema = "Core")]
    public class Currency : BaseModel
    {

        [Required(ErrorMessage = "Code is required")]
        public string Code { get; set; }
        [Required(ErrorMessage = "NameArabic is required")]
        public string NameArabic { get; set; }
        [Required(ErrorMessage = "NameEnglish is required")]
        public string NameEnglish { get; set; }

    }
}