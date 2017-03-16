using Bytes2you.Validation;
using MeetMe.Services.Contracts;
using MeetMe.Web.Models.Publications;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MeetMe.Web.Controllers
{
    [Authorize]
    public class PublicationController : Controller
    {
        private readonly byte[] EmptyPublicationImage = new byte[0];
        private readonly IPublicationService publicationService;
        private readonly IMapperService mapperService;
        private readonly IImageService imageService;
        private readonly ITextService textService;

        public PublicationController(
            IPublicationService publicationService,
            IMapperService mapperService,
            IImageService imageService,
            ITextService textService)
        {
            Guard.WhenArgument(publicationService, "PublicationService").IsNull().Throw();
            Guard.WhenArgument(mapperService, "MapperService").IsNull().Throw();
            Guard.WhenArgument(imageService, "ImageService").IsNull().Throw();
            Guard.WhenArgument(textService, "TextService").IsNull().Throw();

            this.publicationService = publicationService;
            this.mapperService = mapperService;
            this.imageService = imageService;
            this.textService = textService;
        }

        [HttpGet]
        public ActionResult Publications(string id)
        {
            var publications = this.publicationService.UserPublications(id);
            var model = new List<PublicationViewModel>();

            foreach (var publication in publications)
            {
                var userImageUrl = this.imageService.ByteArrayToImageUrl(publication.Author.ProfileImage.Content);
                string publicationImageUrl = this.imageService.ByteArrayToImageUrl(publication.Image.Content);
                var mappedPublication = this.mapperService.MapObject<PublicationViewModel>(publication);
                mappedPublication.AuthorImageUrl = userImageUrl;
                mappedPublication.PublicationImageUrl = publicationImageUrl;
                model.Add(mappedPublication);
            }

            return this.PartialView("_PublicationPartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPublication(string content, string userId, string imageBase64)
        {
            if (imageBase64 != string.Empty)
            {
                var base64 = this.textService.ConvertBase64(imageBase64);
                this.publicationService.CreatePublication(content, userId, base64);
            }
            else
            {
                this.publicationService.CreatePublication(content, userId, this.EmptyPublicationImage);
            }

            var publications = this.publicationService.UserPublications(userId);
            var model = new List<PublicationViewModel>();

            foreach (var publication in publications)
            {
                var userImageUrl = this.imageService.ByteArrayToImageUrl(publication.Author.ProfileImage.Content);
                var publicationImageUrl = this.imageService.ByteArrayToImageUrl(publication.Image.Content);
                var mappedPublication = this.mapperService.MapObject<PublicationViewModel>(publication);
                mappedPublication.AuthorImageUrl = userImageUrl;

                mappedPublication.PublicationImageUrl = publicationImageUrl;
                model.Add(mappedPublication);
            }

            return PartialView("_PublicationPartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(int id, string comment, string userId)
        {
            this.publicationService.CreatePublicationComment(id, comment, userId);

            var publication = this.publicationService.GetById(id);
            var mappedPublication = this.mapperService.MapObject<PublicationViewModel>(publication);
            foreach (var publicationComment in mappedPublication.Comments)
            {
                var userLogoUrl = this.imageService.ByteArrayToImageUrl(publicationComment.Image);
                publicationComment.AuthorImageUrl = userLogoUrl;
            }

            var model = mappedPublication.Comments.OrderByDescending(x => x.CreatedOn).ToList();
            return this.PartialView("_PublicationCommentPartial", model);
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Comments(int id)
        {
            var publication = this.publicationService.GetById(id);
            var mappedPublication = this.mapperService.MapObject<PublicationViewModel>(publication);
            foreach (var comment in mappedPublication.Comments)
            {
                var userLogoUrl = this.imageService.ByteArrayToImageUrl(comment.Image);
                comment.AuthorImageUrl = userLogoUrl;
            }

            var model = mappedPublication.Comments.OrderByDescending(x => x.CreatedOn).ToList();
            return this.PartialView("_PublicationCommentPartial", model);
        }
    }
}