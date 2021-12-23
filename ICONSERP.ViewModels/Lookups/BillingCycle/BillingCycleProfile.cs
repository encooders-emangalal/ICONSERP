using AutoMapper;
using ICONSERP.ViewModels.Lookups.BillingCycle;
using ICONSERP.Models.Models;

namespace ICONSERP.ViewModels
{
    public class CountryCycleProfile : Profile
    {
        public CountryCycleProfile()
        {
            CreateMap<CountryEditViewModel, BillingCycle>(MemberList.None);
            CreateMap<BillingCycle, CountryViewModel>().AfterMap((src, dest, c) => { });
            CreateMap<BillingCycle, CountryEditViewModel>().AfterMap((src, dest, c) => { });
        }
    }
}
