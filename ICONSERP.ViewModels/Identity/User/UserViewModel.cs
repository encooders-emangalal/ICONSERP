
namespace ICONSERP.ViewModels.Identity
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            UserRoles = new List<UserRoleViewModel>();
        }
        public long ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsPasswordUpdated { get; set; }
        public List<UserRoleViewModel> UserRoles { get; set; }
    }
}
