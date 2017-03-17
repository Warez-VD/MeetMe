using System.Web.Mvc;
using Bytes2you.Validation;
using MeetMe.Services.Contracts;

namespace MeetMe.Web.Controllers
{
    [Authorize]
    public class PublicationController : Controller
    {
        private readonly byte[] EmptyPublicationImage = new byte[0];
        private readonly IPublicationService publicationService;
        private readonly ITextService textService;
        private readonly IViewModelService viewModelService;

        public PublicationController(
            IPublicationService publicationService,
            ITextService textService,
            IViewModelService viewModelService)
        {
            Guard.WhenArgument(publicationService, "PublicationService").IsNull().Throw();
            Guard.WhenArgument(textService, "TextService").IsNull().Throw();
            Guard.WhenArgument(viewModelService, "ViewModelService").IsNull().Throw();

            this.publicationService = publicationService;
            this.textService = textService;
            this.viewModelService = viewModelService;
        }

        [HttpGet]
        public ActionResult Publications(string id)
        {
            var publications = this.publicationService.UserPublications(id);
            var model = this.viewModelService.GetMappedPublications(publications);

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
            var model = this.viewModelService.GetMappedPublications(publications);

            return PartialView("_PublicationPartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(int id, string comment, string userId)
        {
            this.publicationService.CreatePublicationComment(id, comment, userId);

            var publication = this.publicationService.GetById(id);
            var model = this.viewModelService.GetMappedComments(publication);

            return this.PartialView("_PublicationCommentPartial", model);
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Comments(int id)
        {
            var publication = this.publicationService.GetById(id);
            var model = this.viewModelService.GetMappedComments(publication);

            return this.PartialView("_PublicationCommentPartial", model);
        }
    }
}