using System.Linq;
using MeetMe.Services.Contracts;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using Bytes2you.Validation;

namespace MeetMe.Web.Hubs
{
    public class Notification : Hub
    {
        private const string PublicationLike = "{0} liked your publication";
        private const string PublicationComment = "{0} commented your publication";

        private readonly IUserService userService;
        private readonly IStatisticService statisticService;
        private readonly IPublicationService publicationService;

        public Notification(
            IUserService userService,
            IStatisticService statisticService,
            IPublicationService publicationService)
        {
            Guard.WhenArgument(userService, "UserService").IsNull().Throw();
            Guard.WhenArgument(statisticService, "StatisticService").IsNull().Throw();
            Guard.WhenArgument(publicationService, "PublicationService").IsNull().Throw();

            this.userService = userService;
            this.statisticService = statisticService;
            this.publicationService = publicationService;
        }

        public void SendNotification(string content, string userId)
        {
            var user = this.userService.GetByIndentityId(userId);
            var friendsIds = user.Friends.Select(x => x.AspIdentityUserId).ToList();

            this.statisticService.AddNotificationStatistic(userId);

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
            //TODO: add as notification
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