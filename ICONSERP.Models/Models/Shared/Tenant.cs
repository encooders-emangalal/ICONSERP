 
using ICONSERP.Models.Models.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICONSERP.Models.Models.Shared
{
    [Table("Tenant", Schema = "Core")]
    public class Tenant : BaseModel
    {

        public string TenantCode { get; set; }
        public string TenantNameArabic { get; set; }
        public string TenantNameEnglish { get; set; }
        public string AccountName { get; set; }
        public string WebSite { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNo { get; set; }
        public string FaxNo { get; set; }
        #region Country
        [ForeignKey(nameof(Country))]
        public Guid CountryId { get; set; }
        public Country Country { get; set; }
        #endregion

        public string StateName { get; set; }
        public string CityName { get; set; }
        public string ZipCode { get; set; }

        #region Proffession
        [ForeignKey(nameof(Proffession))]
        public Guid ProffessionId { get; set; }
        public Proffession Proffession { get; set; }
        #endregion

        public string ContactName { get; set; }
        public string ContactEmailAddress { get; set; }
        public string ContactPhoneNo { get; set; }
        public string ContactMobileNo { get; set; }
        public DateTime RegisterationDate { get; set; }




        public virtual List<User> Users { get; set;}        
        //[ForeignKey(nameof(Owner))]
        //public Guid UserId { get; set; }
        //public User User { get; set; }
    }
}
