using System.ComponentModel.DataAnnotations.Schema;

using ICONSERP.Models.Models.Identity;

namespace ICONSERP.Models.Identity
{
    [Table("LogType", Schema = "Identity")]

    public class LogType : BaseModel
    {
        public string NameArabic { get; set; }
        public string NameEnglish { get; set; }
        public virtual ICollection<TokenLog> TokenLogs { get; set; }
    }
}
