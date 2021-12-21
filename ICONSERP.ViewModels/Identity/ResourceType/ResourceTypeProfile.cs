using AutoMapper;
using ICONSERP.Models;
using ICONSERP.Models.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICONSERP.ViewModels.Identity
{
    public class ResourceTypeProfile : Profile
    {
        public ResourceTypeProfile()
        {
            CreateMap<ResourceTypeEditViewModel, ResourceType>(MemberList.None);
            CreateMap<ResourceType, ResourceTypeViewModel>().AfterMap(
                            (src, dest, c) =>
                            {
                            }
                            );
        }
    }
}
