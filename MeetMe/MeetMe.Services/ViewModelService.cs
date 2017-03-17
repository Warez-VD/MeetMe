using MeetMe.Services.Contracts;
using System.Collections.Generic;
using MeetMe.Data.Models;
using MeetMe.Web.Models.Publications;
using Bytes2you.Validation;
using System.Linq;

namespace MeetMe.Services
{
    public class ViewModelService : IViewModelService
    {
        private readonly IMapperService mapperService;
        private readonly IImageService imageService;

        public ViewModelService(
            IMapperService mapperService,
            IImageService imageService)
        {
            Guard.WhenArgument(mapperService, "MapperService").IsNull().Throw();
            Guard.WhenArgument(imageService, "ImageService").IsNull().Throw();

            this.mapperService = mapperService;
            this.imageService = imageService;
        }

        public IEnumerable<PublicationViewModel> GetMappedPublications(IEnumerable<Publication> publications)
        {
            var result = new List<PublicationViewModel>();

            foreach (var publication in publications)
            {
                var userImageUrl = this.imageService.ByteArrayToImageUrl(publication.Author.ProfileImage.Content);
                var publicationImageUrl = this.imageService.ByteArrayToImageUrl(publication.Image.Content);
                var mappedPublication = this.mapperService.MapObject<PublicationViewModel>(publication);
                mappedPublication.AuthorImageUrl = userImageUrl;

                mappedPublication.PublicationImageUrl = publicationImageUrl;
                result.Add(mappedPublication);
            }

            return result;
        }

        public IList<CommentViewModel> GetMappedComments(Publication publication)
        {
            var mappedPublication = this.mapperService.MapObject<PublicationViewModel>(publication);
            foreach (var publicationComment in mappedPublication.Comments)
            {
                var userLogoUrl = this.imageService.ByteArrayToImageUrl(publicationComment.Image);
                publicationComment.AuthorImageUrl = userLogoUrl;
            }

            var result = mappedPublication.Comments.OrderByDescending(x => x.CreatedOn).ToList();
            return result;
        }
    }
}
