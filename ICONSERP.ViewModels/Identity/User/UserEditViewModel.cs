using System.ComponentModel.DataAnnotations;

namespace ICONSERP.ViewModels.Identity
{
    public class UserEditViewModel
    {
        public UserEditViewModel()
        {
            UserRoles = new List<UserRoleEditViewModel>();
        }
        public long ID { get; set; }
        // [Required]
        public string UserName { get; set; }
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public List<UserRoleEditViewModel> UserRoles { get; set; }
    }
}
