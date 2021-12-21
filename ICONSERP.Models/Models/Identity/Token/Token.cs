 
using ICONSERP.Models.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ICONSERP.Models.Models.Identity
{
    [Table("Token", Schema = "Identity")]

    public class Token : BaseModel
    {
        public virtual TokenType TokenType { get; set; }
        public long? TokenTypeID { get; set; }
        public virtual User User { get; set; }
        public Guid UserID { get; set; }
        public string Code { get; set; }
        public string IP { get; set; }
        public string UserAgent { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime? LoggedOutDate { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<TokenLog> TokenLogs { get; set; }
    }
}
