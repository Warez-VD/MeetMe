using MeetMe.Data.Models;
using MeetMe.Web.Models.Contracts;

namespace MeetMe.Web.Models.Navigation
{
    public class StatisticViewModel : IMapFrom<Statistic>
    {
        public int NotificationsCount { get; set; }

        public int MessagesCount { get; set; }
    }
}