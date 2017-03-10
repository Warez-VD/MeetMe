using MeetMe.Data.Models;

namespace MeetMe.Services.Contracts
{
    public interface IStatisticFactory
    {
        Statistic CreateStatistic(int notificationCount, int messageCount, int userId);
    }
}
