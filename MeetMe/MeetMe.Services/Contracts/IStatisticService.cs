using MeetMe.Data.Models;

namespace MeetMe.Services.Contracts
{
    public interface IStatisticService
    {
        void CreateStatistic(string userId);

        void AddNotificationStatistic(string userId);

        void AddMessageStatistic(string userId);

        Statistic GetUserStatistic(string userId);
    }
}
