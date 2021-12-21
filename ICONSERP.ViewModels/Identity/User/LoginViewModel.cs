
using System.ComponentModel.DataAnnotations;
using System.Text;
using static ICONSERP.Models.Enums.Enums;

namespace ICONSERP.ViewModels.Identity
{
    public class LoginViewModel
    {
        [Required, MinLength(4)]
        public string UserName { get; set; }

        [Required, MinLength(4)]
        public string Password { get; set; }
        public string IP { get; set; }
        public string UserAgent { get; set; }
        public DateTime ExpirationDate { get; set; }
        public UserType UserType { get; set; }
    }
}
