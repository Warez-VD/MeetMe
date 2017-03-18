using MeetMe.Web.Models.Contracts;
using System;
using AutoMapper;
using MeetMe.Data.Models;

namespace MeetMe.Web.Models.Notifications
{
    public class NotificationViewModel : ICustomMappings
    {
        public int Id { get; set; }

        public string Author { get; set; }

        public string AuthorImageUrl { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsFriendship { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Notification, NotificationViewModel>()
                     .ForMember(dest => dest.Author, opts => opts.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"));
        }
    }
}
