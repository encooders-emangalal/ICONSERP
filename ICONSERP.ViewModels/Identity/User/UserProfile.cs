using AutoMapper;
using ICONSERP.Models.Models.Identity;

namespace ICONSERP.ViewModels.Identity
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserEditViewModel, User>(MemberList.None).ForMember(i => i.UserRoles, opt => opt.Ignore());
            CreateMap<UserEditViewModel, UserViewModel>(MemberList.None);
            CreateMap<User, UserViewModel>().ForMember(i => i.UserRoles, opt => opt.Ignore()).AfterMap(
                            (src, dest, c) =>
                            {
                            }
                            );
        }
    }
}
