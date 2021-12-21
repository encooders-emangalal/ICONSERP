using AutoMapper;
using ICONSERP.Models;
using ICONSERP.Models.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICONSERP.ViewModels.Identity { 
    public class TokenLogProfile : Profile
    {
        public TokenLogProfile()
        {
            CreateMap<TokenLogEditViewModel, TokenLog>(MemberList.None);
            CreateMap<TokenLog, TokenLogViewModel>().AfterMap(
                            (src, dest, c) =>
                            {
                            }
                            );
        }
    }
}
