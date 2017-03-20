using System.Linq;
using System.Threading.Tasks;
using Bytes2you.Validation;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;

namespace MeetMe.Web.Hubs
{
    public class Notification : Hub
    {
        private const string PublicationCreation = "{0} posted new publication";
        private const string PublicationLike = "{0} liked your publication";
        private const string PublicationComment = "{0} commented your publication";
        private const string FriendshipInvitation = "You have new friendship invitation";
        private const string FriendshipInvitationContent = "{0} wants to be your friend";
        private const string FriendshipAcceptance = "{0} accepted your friendship invitation";

        private readonly IEFRepository<UserFriend> friendsRepository;
        private readonly IUserService userService;
        private readonly IStatisticService statisticService;
        private readonly IPublicationService publicationService;
        private readonly INotificationService notificationService;

        public Notification(
            IEFRepository<UserFriend> friendsRepository,
            IUserService userService,
            IStatisticService statisticService,
            IPublicationService publicationService,
            INotificationService notificationService)
        {
            Guard.WhenArgument(friendsRepository, "FriendsRepository").IsNull().Throw();
            Guard.WhenArgument(userService, "UserService").IsNull().Throw();
            Guard.WhenArgument(statisticService, "StatisticService").IsNull().Throw();
            Guard.WhenArgument(publicationService, "PublicationService").IsNull().Throw();
            Guard.WhenArgument(notificationService, "NotificationService").IsNull().Throw();

            this.friendsRepository = friendsRepository;
            this.userService = userService;
            this.statisticService = statisticService;
            this.publicationService = publicationService;
            this.notificationService = notificationService;
        }

        public void SendNotification(string content, string userId)
        {
            var user = this.userService.GetByIndentityId(userId);
            var friends = this.friendsRepository
                .All
                .Where(x => x.UserId == user.Id)
                .ToList();

            string message = string.Format(PublicationCreation, user.FullName);
            foreach (var friend in friends)
            {
                this.statisticService.AddNotificationStatistic(friend.FriendId);
                this.notificationService.CreateNotification(user.Id, content, false, friend.FriendId);
                this.Clients.Group(friend.FriendIdentityId).addNotification(message);
            }
        }

        public void AddLikeNotification(int id, string userId, string publicationAuthorId, string elementId)
        {
            if (userId != publicationAuthorId)
            {
                var user = this.userService.GetByIndentityId(userId);
                var publicationAuthor = this.userService.GetByIndentityId(publicationAuthorId);
                string message = string.Format(PublicationLike, user.FullName);

                this.notificationService.CreateNotification(user.Id, message, false, publicationAuthor.Id);
                this.statisticService.AddNotificationStatistic(userId);
                
                this.Clients.Group(publicationAuthorId).addNotification(message);
            }

            this.publicationService.AddLike(id);
            this.Clients.Group(userId).likePublication(elementId);
        }

        public void AddDislikeNotification(int id, string elementId)
        {
            this.publicationService.AddDislike(id);
            this.Clients.Caller.dislikePublication(elementId);
        }

        public void AddCommentNotification(string publicationAuthorId, string currentUserId)
        {
            this.statisticService.AddNotificationStatistic(publicationAuthorId);
            var currentUser = this.userService.GetByIndentityId(currentUserId);
            var publicationAuthor = this.userService.GetByIndentityId(publicationAuthorId);
            string message = string.Format(PublicationComment, currentUser.FullName);

            this.notificationService.CreateNotification(currentUser.Id, message, false, publicationAuthor.Id);
            this.Clients.Group(publicationAuthorId).addNotification(message);
        }

        public void AddFriend(string currentUserId, int friendId)
        {
            var currentUser = this.userService.GetByIndentityId(currentUserId);
            string message = string.Format(FriendshipInvitationContent, currentUser.FullName);

            var friend = this.userService.GetById(friendId);
            this.statisticService.AddNotificationStatistic(friend.AspIdentityUserId);
            
            this.notificationService.CreateNotification(currentUser.Id, message, true, friendId);
            this.Clients.Caller.addFriend(friendId);
            this.Clients.Group(friend.AspIdentityUserId).addNotification(FriendshipInvitation);
        }

        public void AcceptFriendship(string userId, int receiverId)
        {
            var user = this.userService.GetByIndentityId(userId);
            var receiverUser = this.userService.GetById(receiverId);
            this.userService.AddFriend(receiverUser.AspIdentityUserId, user.Id);
            var message = string.Format(FriendshipAcceptance, user.FullName);
            
            this.statisticService.AddNotificationStatistic(receiverUser.AspIdentityUserId);
            this.statisticService.RemoveNotificationStatistic(user.AspIdentityUserId);
            this.notificationService.CreateNotification(user.Id, message, false, receiverUser.Id);
            this.Clients.Group(receiverUser.AspIdentityUserId).addNotification(message);
            this.Clients.Caller.removeOneNotification();
        }

        public override Task OnConnected()
        {
            if (this.Context.User.Identity.GetUserId() != null)
            {
                string userId = this.Context.User.Identity.GetUserId();
                this.Groups.Add(this.Context.ConnectionId, userId);
            }

            return base.OnConnected();
        }
    }
}