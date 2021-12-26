using ICONSERP.ViewModels.Lookups;
using ICONSERP.ViewModels.Shared;

namespace ICONSERP.Services
{
    public interface ICountryService : IBaseService<CountryEditViewModel, CountryViewModel>
    {
        PagingViewModel Get(string name = "", string Code = "", string orderBy = "ID", bool isAscending = false, int pageIndex = 1, int pageSize = 20);
        bool IsExist(Guid ID, string Code, string nameArabic, string nameEnglish);
    }
}
