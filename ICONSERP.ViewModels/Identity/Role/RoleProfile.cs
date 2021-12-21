using AutoMapper;
using ICONSERP.ViewModels.Identity;
using ICONSERP.Models.Models.Identity;

namespace ICONSERP.ViewModels
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleEditViewModel, Role>(MemberList.None).ForMember(i => i.RoleModuleResourcePermissions, opt => opt.Ignore());
            CreateMap<Role, RoleViewModel>().AfterMap(
                            (src, dest, c) =>
                            {
                            }
                            );
        }
    }
}
