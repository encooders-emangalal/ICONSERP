using System.ComponentModel.DataAnnotations;

namespace ICONSERP.ViewModels.Identity
{
    public class RoleEditViewModel
    {
        public RoleEditViewModel()
        {
            RoleModuleResourcePermissions = new List<RoleModuleResourcePermissionEditViewModel>();
        }
        public Guid ID { get; set; }
        public string Code { get; set; }
        [Required]
        public string NameArabic { get; set; }
        [Required]
        public string NameEnglish { get; set; }
        public List<RoleModuleResourcePermissionEditViewModel> RoleModuleResourcePermissions { get; set; }
    }
}
