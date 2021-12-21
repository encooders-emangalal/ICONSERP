using AutoMapper;
using ICONSERP.Models;
using ICONSERPAPI.Models.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICONSERP.ViewModels.Identity
{
    public class ResourceProfile : Profile
    {
        public ResourceProfile()
        {
            CreateMap<ResourceEditViewModel, Resource>(MemberList.None);
            CreateMap<Resource, ResourceViewModel>().AfterMap(
                            (src, dest, c) =>
                            {
                            }
                            );
        }
    }
}
