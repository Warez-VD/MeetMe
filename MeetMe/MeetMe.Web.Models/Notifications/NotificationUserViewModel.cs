using AutoMapper;
using MeetMe.Data.Models;
using MeetMe.Web.Models.Contracts;
using System;

namespace MeetMe.Web.Models.Notifications
{
    public class NotificationUserViewModel : ICustomMappings
    {
        public int Id { get; set; }

        public string Author { get; set; }

        public string AuthorImageUrl { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsFriendship { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Notification, NotificationUserViewModel>()
                     .ForMember(dest => dest.Author, opts => opts.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"));
        }
    }
}
