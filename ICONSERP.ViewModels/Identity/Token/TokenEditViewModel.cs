using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ICONSERP.ViewModels.Identity
{
    public class TokenEditViewModel
    {
        public long ID { get; set; }
        public long? TokenTypeID { get; set; }
        [Required]
        public long UserID { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string IP { get; set; }
        [Required]
        public string UserAgent { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }
        public DateTime? LoggedOutDate { get; set; }
        [Required]
        public bool Active { get; set; }
    }
}
