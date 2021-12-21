using ICONSERP.ViewModels.Shared;

namespace ICONSERP.ViewModels.Identity
{
    public class PrivilegeItemViewModel
    {
        public PrivilegeItemViewModel()
        {
            Permissions = new List<SelectListItemViewModel>();
        }
        public long ResourceID { get; set; }
        public string ResourceName { get; set; }
        public string ResourceNameEnglish { get; set; }
        public string Url { get; set; }
        public int Number { get; set; }
        public List<SelectListItemViewModel> Permissions { get; set; }
    }
}
