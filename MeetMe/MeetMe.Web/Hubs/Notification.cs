using System.Linq;
using MeetMe.Services.Contracts;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using Bytes2you.Validation;
using System.Collections.Generic;

namespace MeetMe.Web.Hubs
{
    public class Notification : Hub
    {
        private const string PublicationLike = "{0} liked your publication";
        private const string PublicationComment = "{0} commented your publication";
        private const string FriendshipInvitation = "You have new friendship invitation";
        private const string FriendshipInvitationContent = "{0} wants to be your friend";
        private const string FriendshipAcceptance = "{0} accepted your friendship invitation";

        private readonly IUserService userService;
        private readonly IStatisticService statisticService;
        private readonly IPublicationService publicationService;
        private readonly INotificationService notificationService;

        public Notification(
            IUserService userService,
            IStatisticService statisticService,
            IPublicationService publicationService,
            INotificationService notificationService)
        {
            Guard.WhenArgument(userService, "UserService").IsNull().Throw();
            Guard.WhenArgument(statisticService, "StatisticService").IsNull().Throw();
            Guard.WhenArgument(publicationService, "PublicationService").IsNull().Throw();
            Guard.WhenArgument(notificationService, "NotificationService").IsNull().Throw();

            this.userService = userService;
            this.statisticService = statisticService;
            this.publicationService = publicationService;
            this.notificationService = notificationService;
        }

        public void SendNotification(string content, string userId)
        {
            var user = this.userService.GetByIndentityId(userId);
            // var friendsIds = user.Friends.Select(x => x.AspIdentityUserId).ToList();

            this.statisticService.AddNotificationStatistic(userId);
            // TODO: foreach friend add notification
            // this.notificationService.CreateNotification(user.Id, content, false, 1);

            //TODO: Only friends
            this.Clients.All.addNotification();
        }

        public void AddLikeNotification(int id, string userId, string elementId)
        {
            //TODO: add as notification
            var user = this.userService.GetByIndentityId(this.Context.User.Identity.GetUserId());
            this.publicationService.AddLike(id);
            this.statisticService.AddNotificationStatistic(userId);
            this.Clients.Group(userId).likePublication(elementId);
            string fullName = $"{user.FirstName} {user.LastName}";
            this.Clients.Group(userId).addNotification(string.Format(PublicationLike, fullName));
        }

        public void AddDislikeNotification(int id, string elementId)
        {
            this.publicationService.AddDislike(id);
            this.Clients.Caller.dislikePublication(elementId);
        }

        public void AddCommentNotification(string publicationAuthorId, string currentUserId)
        {
            //TODO: add as notification
            this.statisticService.AddNotificationStatistic(publicationAuthorId);
            var currentUser = this.userService.GetByIndentityId(currentUserId);
            string fullName = $"{currentUser.FirstName} {currentUser.LastName}";
            this.Clients.Group(publicationAuthorId).addNotification(string.Format(PublicationComment, fullName));
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