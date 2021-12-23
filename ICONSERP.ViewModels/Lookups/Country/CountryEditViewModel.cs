using System.ComponentModel.DataAnnotations;

namespace ICONSERP.ViewModels.Lookups
{
    public class CountryEditViewModel
    {
        [Required(ErrorMessage = "Code is required")]
        public string Code { get; set; }
        [Required]
        public string NameArabic { get; set; }
        [Required]
        public string NameEnglish { get; set; }
      
      

    }
}
