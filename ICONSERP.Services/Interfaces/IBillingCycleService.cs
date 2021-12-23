using ICONSERP.ViewModels.Lookups.BillingCycle;
using ICONSERP.ViewModels.Shared;


namespace ICONSERP.Services
{
    public interface IBillingCycleService : IBaseService<CountryEditViewModel, CountryViewModel>
    {
        PagingViewModel Get(string name = "", string orderBy = "ID", bool isAscending = false, int pageIndex = 1, int pageSize = 20);
        bool IsExist(string nameArabic, string nameEnglish, int DisplayOrder);
    }
}
