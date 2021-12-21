namespace ICONSERP.ViewModels.Identity
{
    public class RoleModuleResourcePermissionViewModel
    {
        public RoleModuleResourcePermissionViewModel()
        {
            Role = new RoleViewModel();
            ModuleResource = new ModuleResourceViewModel();
            Permission = new PermissionViewModel();
        }
        public long ID { get; set; }
        public RoleViewModel Role { get; set; }
        public ModuleResourceViewModel ModuleResource { get; set; }
        public PermissionViewModel Permission { get; set; }
    }
}
