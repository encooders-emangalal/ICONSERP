using AutoMapper;
using ICONSERP.Models.Models.Identity;

namespace ICONSERP.ViewModels.Identity
{
    public class PermissionProfile : Profile
    {
        public PermissionProfile()
        {
            CreateMap<PermissionEditViewModel, Permission>(MemberList.None);
            CreateMap<Permission, ModuleViewModel>().AfterMap((src, dest, c) =>{});
        }
    }
}
