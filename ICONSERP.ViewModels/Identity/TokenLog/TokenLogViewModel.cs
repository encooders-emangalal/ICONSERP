using System;
using System.Collections.Generic;
using System.Text;

namespace ICONSERP.ViewModels.Identity
{
    public class TokenLogViewModel
    {
        public long ID { get; set; }
        public long? TokenID { get; set; }
        public long? LogTypeID { get; set; }
        public string IP { get; set; }
        public string UserAgent { get; set; }
        public string UserMachine { get; set; }
        public string Data { get; set; }
        public string OtherInfo { get; set; }
        public string URL { get; set; }
        public string ErrorInfo { get; set; }
        public string Message { get; set; }
        public string MessageTemplate { get; set; }
        public string Level { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Exception { get; set; }
        public string Properties { get; set; }
    }
}
