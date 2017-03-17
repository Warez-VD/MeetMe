using MeetMe.Services.Contracts;
using System.Collections.Generic;
using System.Linq;
using MeetMe.Web.Models.Search;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using Bytes2you.Validation;

namespace MeetMe.Services
{
    public class SearchService : ISearchService
    {
        private readonly IEFRepository<CustomUser> userRepository;
        private readonly IMapperService mapperService;
        private readonly IImageService imageService;

        public SearchService(
            IEFRepository<CustomUser> userRepository,
            IMapperService mapperService,
            IImageService imageService)
        {
            Guard.WhenArgument(userRepository, "UserRepository").IsNull().Throw();
            Guard.WhenArgument(mapperService, "MapperService").IsNull().Throw();
            Guard.WhenArgument(imageService, "ImageService").IsNull().Throw();

            this.userRepository = userRepository;
            this.mapperService = mapperService;
            this.imageService = imageService;
        }

        public IEnumerable<SearchUserViewModel> SearchedUsers(string pattern, int skip, int count)
        {
            var users = this.userRepository.All
                .Where(x => x.FirstName.Contains(pattern))
                .OrderBy(x => x.Id)
                .Skip(skip)
                .Take(count)
                .ToList();

            var result = users.Select(x => this.mapperService.MapObject<SearchUserViewModel>(x)).ToList();
            for (int i = 0; i < users.Count; i++)
            {
                result[i].ImageUrl = this.imageService.ByteArrayToImageUrl(users[i].ProfileImage.Content);
            }

            return result;
        }
    }
}
