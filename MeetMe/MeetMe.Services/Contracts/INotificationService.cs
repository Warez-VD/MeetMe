using MeetMe.Web.Models.Notifications;
using System.Collections.Generic;

namespace MeetMe.Services.Contracts
{
    public interface INotificationService
    {
        void CreateNotification(int userId, string content, bool isFriendship, int targetId);

        IEnumerable<NotificationUserViewModel> UserNotifications(int skip, int count, string userId);

        void RemoveNotification(int id);

        void RemoveAllNotifications(string userId);
    }
}
