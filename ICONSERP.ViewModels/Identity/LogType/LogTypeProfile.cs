using AutoMapper;
using ICONSERP.Models.Identity;

namespace ICONSERP.ViewModels.Identity
{
    public class LogTypeProfile : Profile
    {
        public LogTypeProfile()
        {
            CreateMap<LogTypeEditViewModel, LogType>(MemberList.None);
            CreateMap<LogType, LogTypeViewModel>().AfterMap(
                            (src, dest, c) =>
                            {
                            }
                            );
        }
    }
}
