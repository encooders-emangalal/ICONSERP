namespace ICONSERP.ViewModels.Identity
{
    public class ResourceViewModel
    {
        public long ID { get; set; }
        public ResourceTypeViewModel ResourceType { get; set; }
        public ResourceViewModel ParentResource { get; set; }
        public string Code { get; set; }
        public string NameArabic { get; set; }
        public string NameEnglish { get; set; }
        public string Url { get; set; }
        public long Number { get; set; }
    }
}
