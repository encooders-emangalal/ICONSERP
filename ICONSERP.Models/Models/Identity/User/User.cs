using ICONSERP.Models.BaseModel;
using ICONSERPAPI.Models.Models.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICONSERPAPI.Models.Models.Identity
{
    [Table("User", Schema = "Identity")]

    public class User : BaseModel
    {
        public User()
        {
            UserRoles = new List<UserRole>();
        }
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }
        [NotMapped]
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        #region Tenant
        [ForeignKey(nameof(Tenant))]
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }
        #endregion

        public string Password { get; set; }
        // public bool IsPasswordUpdated { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<Token> Tokens { get; set; }

    }
}
