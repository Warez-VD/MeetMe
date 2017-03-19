using System.Collections.Generic;
using System.Linq;
using Bytes2you.Validation;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;

namespace MeetMe.Services
{
    public class PublicationService : IPublicationService
    {
        private readonly IEFRepository<Publication> publicationRepository;
        private readonly IEFRepository<UserFriend> friendsRepository;
        private readonly IUserService userService;
        private readonly IUnitOfWork unitOfWork;
        private readonly IPublicationFactory publicationFactory;
        private readonly IDateTimeService dateTimeService;
        private readonly IPublicationImageFactory publicationImageFactory;
        private readonly ICommentService commentService;

        public PublicationService(
            IEFRepository<Publication> publicationRepository,
            IEFRepository<UserFriend> friendsRepository,
            IUserService userService,
            IUnitOfWork unitOfWork,
            IPublicationFactory publicationFactory,
            IDateTimeService dateTimeService,
            IPublicationImageFactory publicationImageFactory,
            ICommentService commentService)
        {
            Guard.WhenArgument(publicationRepository, "PublicationRepository").IsNull().Throw();
            Guard.WhenArgument(friendsRepository, "FriendsRepository").IsNull().Throw();
            Guard.WhenArgument(userService, "UserService").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "UnitOfWork").IsNull().Throw();
            Guard.WhenArgument(publicationFactory, "PublicationFactory").IsNull().Throw();
            Guard.WhenArgument(dateTimeService, "DateTimeService").IsNull().Throw();
            Guard.WhenArgument(publicationImageFactory, "PublicationImageFactory").IsNull().Throw();
            Guard.WhenArgument(commentService, "CommentService").IsNull().Throw();

            this.publicationRepository = publicationRepository;
            this.friendsRepository = friendsRepository;
            this.userService = userService;
            this.unitOfWork = unitOfWork;
            this.publicationFactory = publicationFactory;
            this.dateTimeService = dateTimeService;
            this.publicationImageFactory = publicationImageFactory;
            this.commentService = commentService;
        }

        public void CreatePublication(string content, string userId, byte[] imageContent)
        {
            var user = this.userService.GetByIndentityId(userId);
            var createdOn = this.dateTimeService.GetCurrentDate();
            var publicationImage = this.publicationImageFactory.CreatePublicationImage(imageContent);
            var publication = this.publicationFactory.CreatePublication(content, user.Id, createdOn, publicationImage);
            this.publicationRepository.Add(publication);
            this.unitOfWork.Commit();
        }

        // TODO: unit test
        public IEnumerable<Publication> FriendsPublications(string userId, int skip, int count)
        {
            var user = this.userService.GetByIndentityId(userId);
            var friendsIds = this.friendsRepository.All
                .Where(x => x.UserId == user.Id)
                .Select(x => x.FriendId)
                .ToList();
            friendsIds.Add(user.Id);

            var friendsPublications = this.publicationRepository
                .All
                .Where(x => friendsIds.Contains(x.Author.Id))
                .OrderByDescending(x => x.CreatedOn)
                .Skip(skip)
                .Take(count)
                .ToList();

            return friendsPublications;
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

        public void CreatePublicationComment(int publicationId, string content, string userId)
        {
            var publication = this.publicationRepository.GetById(publicationId);
            var user = this.userService.GetByIndentityId(userId);
            var date = this.dateTimeService.GetCurrentDate();
            var comment = this.commentService.CreatePublicationComment(content, user.Id, date);
            publication.Comments.Add(comment);
            this.publicationRepository.Update(publication);
            this.unitOfWork.Commit();
        }
    }
}
