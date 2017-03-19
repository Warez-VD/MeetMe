using MeetMe.Data.Models;

namespace MeetMe.Services.Contracts
{
    public interface IStatisticService
    {
        void CreateStatistic(string userId);

        void AddNotificationStatistic(string userId);

        void AddNotificationStatistic(int userId);

        void AddMessageStatistic(string userId);

        void RemoveNotificationStatistic(string userId);

        Statistic GetUserStatistic(string userId);

        void MarkAsVisitedNotifications(string userId);
    }
}
