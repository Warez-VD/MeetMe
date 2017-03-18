using System.Collections.Generic;

namespace MeetMe.Web.Models.Notifications
{
    public class NotificationViewModel
    {
        public IEnumerable<NotificationUserViewModel> Notifications { get; set; }
    }
}
