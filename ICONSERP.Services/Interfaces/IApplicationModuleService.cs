using ICONSERP.ViewModels.Lookups.ApplicationModule;
using ICONSERP.ViewModels.Shared;

namespace ICONSERP.Services.Interfaces
{
    public interface IApplicationModuleService : IBaseService<ApplicationModuleEditViewModel, ApplicationModuleViewModel>
    {
        PagingViewModel Get(string name = "", string orderBy = "ID", bool isAscending = false, int pageIndex = 1, int pageSize = 20);
        bool IsExist(Guid id, string nameArabic, string nameEnglish, string Code);
    }
}