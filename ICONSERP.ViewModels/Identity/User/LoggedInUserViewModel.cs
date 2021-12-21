namespace ICONSERP.ViewModels.Identity
{
    public class LoggedInUserViewModel
    {
        public LoggedInUserViewModel()
        {
            Privileges = new List<RoleModuleResourcePermissionViewModel>();
            User = new UserViewModel();
        }
        public UserViewModel User { get; set; }
        public string Token { get; set; }
        public List<RoleModuleResourcePermissionViewModel> Privileges { get; set; }
        public List<PrivilegeViewModel> GroupedPrivileges { get; set; }
    }
}
