﻿using MeetMe.Web.ViewModels.Contracts;
using System;
using AutoMapper;
using MeetMe.Data.Models;

namespace MeetMe.Web.ViewModels.Publications
{
    public class CommentViewModel : ICustomMappings
    {
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Author { get; set; }

        public byte[] Image { get; set; }

        public string AuthorImageUrl { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                    .ForMember(dest => dest.Author, opts => opts.MapFrom(src => $"{src.Author.FirstName} {src.Author.LastName}"))
                    .ForMember(dest => dest.Image, opts => opts.MapFrom(src => src.Author.ProfileImage.Content));
        }
    }
}