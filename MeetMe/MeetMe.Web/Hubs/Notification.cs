using System.Linq;
using MeetMe.Services.Contracts;
using Microsoft.AspNet.SignalR;

namespace MeetMe.Web.Hubs
{
    public class Notification : Hub
    {
        private readonly IUserService userService;
        private readonly IStatisticService statisticService;

        public Notification(
            IUserService userService,
            IStatisticService statisticService)
        {
            this.userService = userService;
            this.statisticService = statisticService;
        }

        public void SendNotification(string content, string userId)
        {
            var user = this.userService.GetByIndentityId(userId);
            var friendsIds = user.Friends.Select(x => x.AspIdentityUserId).ToList();

            this.statisticService.AddNotificationStatistic(userId);

            this.Clients.All.addNotification();
        }
    }
}