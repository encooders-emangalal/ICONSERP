using AutoMapper;
using ICONSERP.Models;
using ICONSERPAPI.Models.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICONSERP.ViewModels.Identity
{
    public class TokenTypeProfile : Profile
    {
        public TokenTypeProfile()
        {
            CreateMap<TokenTypeEditViewModel, TokenType>(MemberList.None);
            CreateMap<TokenType, TokenTypeViewModel>().AfterMap(
                            (src, dest, c) =>
                            {
                            }
                            );
        }
    }
}
