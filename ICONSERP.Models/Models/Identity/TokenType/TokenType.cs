using ICONSERP.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ICONSERPAPI.Models.Models.Identity
{
    [Table("TokenType", Schema = "Identity")]

    public class TokenType : BaseModel
    {
        public string NameArabic { get; set; }
        public string NameEnglish { get; set; }
        public virtual ICollection<Token> Tokens { get; set; }
    }
}
