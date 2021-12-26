using System.ComponentModel.DataAnnotations;

namespace ICONSERP.ViewModels.Lookups.BillingCycle
{
    public class BillingCycleEditViewModel
    {
      
        [Required]
        public string NameArabic { get; set; }
        [Required]
        public string NameEnglish { get; set; }
        public int DisplayOrder { get; set; }
      

    }
}
