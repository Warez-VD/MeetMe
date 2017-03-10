using MeetMe.Data.Models;
using MeetMe.Web.ViewModels.Contracts;

namespace MeetMe.Web.ViewModels.Navigation
{
    public class StatisticViewModel : IMapFrom<Statistic>
    {
        public int NotificationsCount { get; set; }

        public int MessagesCount { get; set; }
    }
}