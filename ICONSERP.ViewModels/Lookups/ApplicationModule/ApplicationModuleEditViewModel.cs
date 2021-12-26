using System.ComponentModel.DataAnnotations;

namespace ICONSERP.ViewModels.Lookups.ApplicationModule
{
    public class ApplicationModuleEditViewModel
    {
        public Guid ID { get; set; }
        public string? Code { get; set; }
        [Required]
        public string? NameArabic { get; set; }
        [Required]
        public string? NameEnglish { get; set; }
    }
}