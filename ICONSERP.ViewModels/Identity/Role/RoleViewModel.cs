namespace ICONSERP.ViewModels.Identity
{
    public class RoleViewModel
    {
        public RoleViewModel()
        {
            RoleModuleResourcePermissions = new List<RoleModuleResourcePermissionViewModel>();
        }
        public long ID { get; set; }
        public string Code { get; set; }
        public string NameArabic { get; set; }
        public string NameEnglish { get; set; }
        public List<RoleModuleResourcePermissionViewModel> RoleModuleResourcePermissions { get; set; }
    }
}
