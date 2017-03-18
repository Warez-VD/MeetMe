using Bytes2you.Validation;
using MeetMe.Services.Contracts;
using MeetMe.Web.Models.Notifications;
using System.Web.Mvc;

namespace MeetMe.Web.Controllers
{
    public class NotificationController : Controller
    {
        private const int DefaultNotificationsSkip = 0;
        private const int DefaultNotificationsTake = 20;

        private readonly INotificationService notificationService;

        public NotificationController(INotificationService notificationService)
        {
            Guard.WhenArgument(notificationService, "NotificationService").IsNull().Throw();

            this.notificationService = notificationService;
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

        public ActionResult RemoveNotification(int id, string userId)
        {
            this.notificationService.RemoveNotification(id);
            var model = this.notificationService.UserNotifications(DefaultNotificationsSkip, DefaultNotificationsTake, userId);

            return this.PartialView("_NotificationsPartial", model);
        }
    }
}