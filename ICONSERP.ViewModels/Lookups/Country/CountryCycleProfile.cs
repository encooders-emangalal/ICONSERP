using AutoMapper;
using ICONSERP.ViewModels.Lookups.BillingCycle;
using ICONSERP.Models.Models;

namespace ICONSERP.ViewModels
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<CountryEditViewModel, Country>(MemberList.None);
            CreateMap<Country, CountryViewModel>().AfterMap((src, dest, c) => { });
            CreateMap<Country, CountryEditViewModel>().AfterMap((src, dest, c) => { });
        }
    }
}
