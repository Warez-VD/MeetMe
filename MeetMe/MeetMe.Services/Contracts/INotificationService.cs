using System;

namespace MeetMe.Services.Contracts
{
    public interface INotificationService
    {
        void CreateNotification(int userId, string content);
    }
}
