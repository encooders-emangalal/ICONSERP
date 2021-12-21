using AutoMapper;
using ICONSERP.Models;
using ICONSERPAPI.Models.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICONSERP.ViewModels.Identity
{
    public class ModuleResourceProfile : Profile
    {
        public ModuleResourceProfile()
        {
            CreateMap<ModuleResourceEditViewModel, ModuleResource>(MemberList.None);
            CreateMap<ModuleResource, ModuleResourceViewModel>().AfterMap(
                            (src, dest, c) =>
                            {
                            }
                            );
        }
    }
}
