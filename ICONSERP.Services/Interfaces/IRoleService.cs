using ICONSERP.ViewModels.Identity;
using ICONSERP.ViewModels.Shared;

namespace ICONSERP.Services
{
    public interface IRoleService : IBaseService<RoleEditViewModel, RoleViewModel>
    {
        PagingViewModel Get(string name = "", string orderBy = "ID", bool isAscending = false, int pageIndex = 1, int pageSize = 20);
        bool IsExist(Guid id, string nameArabic, string nameEnglish);
        RoleEditViewModel Add(RoleEditViewModel model);
        RoleEditViewModel Edit(RoleEditViewModel model);               
    }
}
