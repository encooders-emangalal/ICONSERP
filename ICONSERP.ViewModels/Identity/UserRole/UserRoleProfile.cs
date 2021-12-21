using AutoMapper;
using ICONSERP.Models;
using ICONSERPAPI.Models.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICONSERP.ViewModels.Identity
{
    public class UserRoleProfile : Profile
    {
        public UserRoleProfile()
        {
            CreateMap<UserRoleEditViewModel, UserRole>(MemberList.None);
            CreateMap<UserRole, UserRoleViewModel>().AfterMap(
                            (src, dest, c) =>
                            {
                            }
                            );
        }
    }
}
