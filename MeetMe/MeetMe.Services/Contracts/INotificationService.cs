using System.Collections.Generic;
using MeetMe.Data.Models;

namespace MeetMe.Services.Contracts
{
    public interface INotificationService
    {
        void CreateNotification(int userId, string content, bool isFriendship, int targetId);

        IEnumerable<Notification> UserNotifications(int skip, int count, string userId);

        void RemoveNotification(int id);

        void RemoveAllNotifications(string userId);
    }
}
