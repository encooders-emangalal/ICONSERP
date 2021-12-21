using AutoMapper;
using ICONSERP.Models;
using ICONSERPAPI.Models.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICONSERP.ViewModels.Identity
{
    public class TokenProfile : Profile
    {
        public TokenProfile()
        {
            CreateMap<TokenEditViewModel, Token>(MemberList.None);
            CreateMap<Token, TokenViewModel>().AfterMap(
                            (src, dest, c) =>
                            {
                            }
                            );
        }
    }
}
