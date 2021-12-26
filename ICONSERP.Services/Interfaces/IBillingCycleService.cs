
using ICONSERP.ViewModels.Lookups.BillingCycle;
using ICONSERP.ViewModels.Shared;


namespace ICONSERP.Services
{
    public interface IBillingCycleService : IBaseService<BillingCycleEditViewModel, BillingCycleViewModel>
    {
        PagingViewModel Get(string name = "", string orderBy = "ID", bool isAscending = false, int pageIndex = 1, int pageSize = 20);
        bool IsExist(Guid id, string nameArabic, string nameEnglish, int DisplayOrder);
    }
}
