using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ICONSERP.Models;
using ICONSERP.Models.BaseModel;
using ICONSERP.Models.Models.Identity;
using ICONSERPAPI.Models.Models.Identity;

namespace ICONSERPAPI.Models.Identity
{
    [Table("LogType", Schema = "Identity")]

    public class LogType : BaseModel
    {
        public string NameArabic { get; set; }
        public string NameEnglish { get; set; }
        public virtual ICollection<TokenLog> TokenLogs { get; set; }
    }
}
