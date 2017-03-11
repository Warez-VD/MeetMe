using Bytes2you.Validation;
using MeetMe.Services.Contracts;
using MeetMe.Web.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeetMe.Web.Controllers
{
    [Authorize]
    public class PublicationController : Controller
    {
        private readonly IPublicationService publicationService;
        private readonly IMapperService mapperService;
        private readonly IImageService imageService;

        public PublicationController(
            IPublicationService publicationService,
            IMapperService mapperService,
            IImageService imageService)
        {
            Guard.WhenArgument(publicationService, "PublicationService").IsNull().Throw();
            Guard.WhenArgument(mapperService, "MapperService").IsNull().Throw();
            Guard.WhenArgument(imageService, "ImageService").IsNull().Throw();

            this.publicationService = publicationService;
            this.mapperService = mapperService;
            this.imageService = imageService;
        }

        [HttpGet]
        public ActionResult Publications(string id)
        {
            var publications = this.publicationService.UserPublications(id);
            var model = new List<PublicationViewModel>();

            foreach (var publication in publications)
            {
                var userImageUrl = this.imageService.ByteArrayToImageUrl(publication.Author.ProfileImage.Content);
                var mappedPublication = this.mapperService.MapObject<PublicationViewModel>(publication);
                mappedPublication.AuthorImageUrl = userImageUrl;
                model.Add(mappedPublication);
            }

            return this.PartialView("_PublicationPartial", model);
        }

        [HttpPost]
        public ActionResult AddPublication(string content, string userId)
        {
            this.publicationService.CreatePublication(content, userId);
            var publications = this.publicationService.UserPublications(userId);
            var model = new List<PublicationViewModel>();

            foreach (var publication in publications)
            {
                var userImageUrl = this.imageService.ByteArrayToImageUrl(publication.Author.ProfileImage.Content);
                var mappedPublication = this.mapperService.MapObject<PublicationViewModel>(publication);
                mappedPublication.AuthorImageUrl = userImageUrl;
                model.Add(mappedPublication);
            }

            return PartialView("_PublicationPartial", model);
        }
    }
}