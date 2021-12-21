using System;
using System.Collections.Generic;
using System.Text;

namespace ICONSERP.ViewModels.Identity 
{ 
    public class TokenViewModel
    {
        public long ID { get; set; }
        public long? TokenTypeID { get; set; }
        public long UserID { get; set; }
        public string Code { get; set; }
        public string IP { get; set; }
        public string UserAgent { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime? LoggedOutDate { get; set; }
        public bool Active { get; set; }
    }
}
