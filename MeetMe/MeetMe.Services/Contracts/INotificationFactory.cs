using System;
using MeetMe.Data.Models;

namespace MeetMe.Services.Contracts
{
    public interface INotificationFactory
    {
        Notification CreateNotification(int userId, string content, DateTime createdOn, bool isNotification);
    }
}
