using AutoMapper;
using ICONSERP.Models;
using ICONSERP.Models.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICONSERP.ViewModels.Identity
{
    public class RoleModuleResourcePermissionProfile : Profile
    {
        public RoleModuleResourcePermissionProfile()
        {
            CreateMap<RoleModuleResourcePermissionEditViewModel, RoleModuleResourcePermission>(MemberList.None);
            CreateMap<RoleModuleResourcePermission, RoleModuleResourcePermissionViewModel>().AfterMap(
                            (src, dest, c) =>
                            {
                            }
                            );
        }
    }
}
