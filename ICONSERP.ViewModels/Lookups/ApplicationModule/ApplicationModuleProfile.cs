using AutoMapper;
using ICONSERP.Models.Models;
using ICONSERP.ViewModels.Lookups.ApplicationModule;

namespace ICONSERP.ViewModels
{
    public class ApplicationModuleProfile : Profile
    {
        public ApplicationModuleProfile()
        {
            CreateMap<ApplicationModuleEditViewModel, ApplicationModule>(MemberList.None);
            CreateMap<ApplicationModule, ApplicationModuleViewModel>().AfterMap((src, dest, c) => { });
            CreateMap<ApplicationModule, ApplicationModuleEditViewModel>().AfterMap((src, dest, c) => { });
        }
    }
}