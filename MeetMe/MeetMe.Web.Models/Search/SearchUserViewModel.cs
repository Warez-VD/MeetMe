using AutoMapper;
using MeetMe.Data.Models;
using MeetMe.Web.Models.Contracts;

namespace MeetMe.Web.Models.Search
{
    public class SearchUserViewModel : ICustomMappings
    {
        public int Id { get; set; }

        public string AspIdentityUserId { get; set; }

        public string FullName { get; set; }

        public string ImageUrl { get; set; }

        public bool IsFriend { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<CustomUser, SearchUserViewModel>()
                     .ForMember(dest => dest.FullName, opts => opts.MapFrom(src => $"{src.FirstName} {src.LastName}"));
        }
    }
}