using Bytes2you.Validation;
using MeetMe.Services.Contracts;
using MeetMe.Web.Models.Notifications;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MeetMe.Web.Controllers
{
    public class NotificationController : Controller
    {
        private const int DefaultNotificationsSkip = 0;
        private const int DefaultNotificationsTake = 20;

        private readonly INotificationService notificationService;
        private readonly IStatisticService statisticService;
        private readonly IUserService userService;

        public NotificationController(
            INotificationService notificationService,
            IStatisticService statisticService,
            IUserService userService)
        {
            Guard.WhenArgument(notificationService, "NotificationService").IsNull().Throw();
            Guard.WhenArgument(statisticService, "StatisticService").IsNull().Throw();
            Guard.WhenArgument(userService, "UserService").IsNull().Throw();

            this.notificationService = notificationService;
            this.statisticService = statisticService;
            this.userService = userService;
        }

        [HttpGet]
        public ActionResult Index(string id)
        {
            var model = new NotificationViewModel();
            model.Notifications = this.notificationService.UserNotifications(DefaultNotificationsSkip, DefaultNotificationsTake, id);

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ShowMoreResults(int skip, int count, string userId)
        {
            var model = this.notificationService.UserNotifications(skip, count, userId);

            return this.PartialView("_NotificationsPartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveNotification(int id, string userId)
        {
            this.notificationService.RemoveNotification(id);
            var model = this.notificationService.UserNotifications(DefaultNotificationsSkip, DefaultNotificationsTake, userId);

            return this.PartialView("_NotificationsPartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveAllNotifications(string id)
        {
            this.notificationService.RemoveAllNotifications(id);
            this.statisticService.MarkAsVisitedNotifications(id);
            var model = new List<NotificationUserViewModel>();

            return this.PartialView("_NotificationsPartial", model);
        }

        [HttpPost]
        public void MarkVisited(string id)
        {
            this.statisticService.MarkAsVisitedNotifications(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AcceptFriendship(string id, int authorId, int notificationId)
        {
            this.userService.AddFriend(id, authorId);
            this.notificationService.RemoveNotification(notificationId);
            var model = this.notificationService.UserNotifications(DefaultNotificationsSkip, DefaultNotificationsTake, id);

            return this.PartialView("_NotificationsPartial", model);
        }
    }
}