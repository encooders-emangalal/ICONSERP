using System;
using System.Collections.Generic;
using System.Text;

namespace ICONSERP.ViewModels.Shared
{
    public class PagingViewModel
    {
        public int PageSize { set; get; }
        public int PageIndex { set; get; }
        public int Records { set; get; }
        public int Pages { set; get; }
        public object Result { set; get; }
    }
}
