using System;
using System.Collections.Generic;
using System.Text;

namespace ICONSERP.ViewModels.Identity
{
    public class PrivilegeViewModel
    {
        public PrivilegeViewModel()
        {
            Resources = new List<PrivilegeItemViewModel>();
        }
        public long ModuleID { get; set; }
        public string ModuleName { get; set; }
        public string ModuleNameEnglish { get; set; }
        public string Url { get; set; }
        public long Number { get; set; }
        public List<PrivilegeItemViewModel> Resources { get; set; }
    }
}
