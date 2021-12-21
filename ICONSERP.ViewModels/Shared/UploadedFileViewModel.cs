using System;
using System.Collections.Generic;
using System.Text;

namespace ICONSERP.ViewModels.Shared
{
    public class UploadedFileViewModel
    {
        public string OriginalFileName { get; set; }
        public string NewFileName { get; set; }
        public string Path { get; set; }
        public string Extension { get; set; }
    }
}
