using AutoMapper;
using ICONSERP.ViewModels.Lookups.BillingCycle;
using ICONSERP.Models.Models;

namespace ICONSERP.ViewModels
{
    public class BillingCycleCycleProfile : Profile
    {
        public BillingCycleCycleProfile()
        {
            CreateMap<BillingCycleEditViewModel, BillingCycle>(MemberList.None);
            CreateMap<BillingCycle, BillingCycleViewModel>().AfterMap((src, dest, c) => { });
            CreateMap<BillingCycle, BillingCycleEditViewModel>().AfterMap((src, dest, c) => { });
        }
    }
}
