using System.Collections.Generic;
using Bytes2you.Validation;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using System.Linq;

namespace MeetMe.Services
{
    public class PublicationService : IPublicationService
    {
        private readonly IEFRepository<Publication> publicationRepository;
        private readonly IUserService userService;
        private readonly IUnitOfWork unitOfWork;
        private readonly IPublicationFactory publicationFactory;
        private readonly IDateTimeService dateTimeService;

        public PublicationService(
            IEFRepository<Publication> publicationRepository,
            IUserService userService,
            IUnitOfWork unitOfWork,
            IPublicationFactory publicationFactory,
            IDateTimeService dateTimeService)
        {
            Guard.WhenArgument(publicationRepository, "PublicationRepository").IsNull().Throw();
            Guard.WhenArgument(userService, "UserService").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "UnitOfWork").IsNull().Throw();
            Guard.WhenArgument(publicationFactory, "PublicationFactory").IsNull().Throw();
            Guard.WhenArgument(dateTimeService, "DateTimeService").IsNull().Throw();

            this.publicationRepository = publicationRepository;
            this.userService = userService;
            this.unitOfWork = unitOfWork;
            this.publicationFactory = publicationFactory;
            this.dateTimeService = dateTimeService;
        }

        public void CreatePublication(string content, string userId)
        {
            var user = this.userService.GetByIndentityId(userId);
            var createdOn = this.dateTimeService.GetCurrentDate();
            var publication = this.publicationFactory.CreatePublication(content, user.Id, createdOn);
            this.publicationRepository.Add(publication);
            this.unitOfWork.Commit();
        }

        public IEnumerable<Publication> FriendsPublications(string userId, int count)
        {
            var user = this.userService.GetByIndentityId(userId);
            var friendsPublications = new List<Publication>();

            foreach (var friend in user.Friends)
            {
                friendsPublications.AddRange(friend.Publications);
            }

            return friendsPublications
                .OrderByDescending(x => x.CreatedOn)
                .Take(count);
        }

        public IEnumerable<Publication> UserPublications(string userId)
        {
            var user = this.userService.GetByIndentityId(userId);
            return user.Publications.OrderByDescending(x => x.CreatedOn);
        }

        public void AddLike(int id)
        {
            var publication = this.publicationRepository.GetById(id);
            publication.Likes += 1;
            this.publicationRepository.Update(publication);
            this.unitOfWork.Commit();
        }

        public void AddDislike(int id)
        {
            var publication = this.publicationRepository.GetById(id);
            publication.Dislikes += 1;
            this.publicationRepository.Update(publication);
            this.unitOfWork.Commit();
        }

        public Publication GetById(int id)
        {
            var publication = this.publicationRepository.GetById(id);
            return publication;
        }
    }
}
