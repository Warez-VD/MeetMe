using MeetMe.Web.Models.Notifications;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MeetMe.Web.Controllers
{
    public class NotificationController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult Notifications(string id)
        {
            var model = new List<NotificationViewModel>()
            {
                new NotificationViewModel()
                {
                    Author = "Mancho",
                    Content = "Some content",
                    CreatedOn = DateTime.UtcNow,
                    IsFriendship = false
                },
                new NotificationViewModel()
                {
                    Author = "Papinho",
                    Content = "Some other content",
                    CreatedOn = DateTime.UtcNow,
                    IsFriendship = true
                }
            };

            return this.PartialView("_NotificationsPartial", model);
        }
    }
}