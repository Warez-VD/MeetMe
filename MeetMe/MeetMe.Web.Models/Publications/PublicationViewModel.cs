using MeetMe.Data.Models;
using MeetMe.Web.Models.Contracts;
using System;
using System.Collections.Generic;
using AutoMapper;

namespace MeetMe.Web.Models.Publications
{
    public class PublicationViewModel : ICustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }
        
        public string Author { get; set; }

        public string AuthorId { get; set; }

        public string AuthorImageUrl { get; set; }

        public string PublicationImageUrl { get; set; }

        public DateTime CreatedOn { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Publication, PublicationViewModel>()
                    .ForMember(dest => dest.Author, opts => opts.MapFrom(src => $"{src.Author.FirstName} {src.Author.LastName}"))
                    .ForMember(dest => dest.AuthorId, opts => opts.MapFrom(src => src.Author.AspIdentityUserId));
        }
    }
}