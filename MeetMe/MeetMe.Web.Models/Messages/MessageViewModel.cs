using System;
using AutoMapper;
using MeetMe.Data.Models;
using MeetMe.Web.Models.Contracts;

namespace MeetMe.Web.Models.Messages
{
    public class MessageViewModel : ICustomMappings
    {
        public string Content { get; set; }

        public string Author { get; set; }

        public string AuthorId { get; set; }

        public string AuthorImageUrl { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsCurrentUserAuthor { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Message, MessageViewModel>()
                     .ForMember(dest => dest.Author, opts => opts.MapFrom(src => src.User.FullName))
                     .ForMember(dest => dest.AuthorId, opts => opts.MapFrom(src => src.User.AspIdentityUserId));
        }
    }
}
