using AutoMapper;
using ICONSERP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ICONSERPAPI.Models.Models.Identity;

namespace ICONSERP.ViewModels.Identity
{
    public class ModuleProfile : Profile
    {
        public ModuleProfile()
        {
            CreateMap<ModuleEditViewModel, Module>(MemberList.None).ForMember(i => i.ModuleResources, opt => opt.Ignore()).AfterMap(
                 (src, dest, c) =>
                 {
                 }
                );
            CreateMap<Module, ModuleViewModel>().AfterMap(
                            (src, dest, c) =>
                            {
                            }
                            );
        }
    }
}
