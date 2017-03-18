using MeetMe.Web.Models.Notifications;
using System.Collections.Generic;

namespace MeetMe.Services.Contracts
{
    public interface INotificationService
    {
        void CreateNotification(int userId, string content, bool isFriendship);

        IEnumerable<NotificationUserViewModel> UserNotifications(int skip, int count, string userId);

        void RemoveNotification(int id);
    }
}
