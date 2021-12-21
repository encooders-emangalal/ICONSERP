namespace ICONSERP.ViewModels.Identity
{
    public class ModuleViewModel
    {
        public ModuleViewModel()
        {
            ModuleResources = new List<ModuleResourceViewModel>();
        }
        public long ID { get; set; }
        public string Code { get; set; }
        public string NameArabic { get; set; }
        public string NameEnglish { get; set; }
        public string Url { get; set; }
        public int Number { get; set; }
        public List<ModuleResourceViewModel> ModuleResources { get; set; }
    }
}
