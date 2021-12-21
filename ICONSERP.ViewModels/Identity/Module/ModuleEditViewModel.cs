using System.ComponentModel.DataAnnotations;

namespace ICONSERP.ViewModels.Identity
{
    public class ModuleEditViewModel
    {
        public ModuleEditViewModel()
        {
            ModuleResources = new List<ModuleResourceEditViewModel>();
        }
        public long ID { get; set; }
        public string Code { get; set; }
        [Required]
        public string NameArabic { get; set; }
        [Required]
        public string NameEnglish { get; set; }
        [Required]
        public string Url { get; set; }
        public int Number { get; set; }

        public List<ModuleResourceEditViewModel> ModuleResources { get; set; }
    }
}
