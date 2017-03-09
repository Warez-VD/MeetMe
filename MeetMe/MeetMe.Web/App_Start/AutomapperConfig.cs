using AutoMapper;
using MeetMe.Data.Models;
using MeetMe.Web.ViewModels.Home;

namespace MeetMe.Web.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<CustomUser, ProfilePartialViewModel>();
                cfg.CreateMap<CustomUser, PersonalInfoViewModel>();
                cfg.CreateMap<CustomUser, PublicationViewModel>()
                    .ForMember(dest => dest.Author, opts => opts.MapFrom(src => $"{src.FirstName} {src.LastName}"));
            });
        }
    }
}