namespace MeetMe.Data.Models
{
    public class Statistic
    {
        public Statistic()
        {
        }

        public Statistic(int notificationCount, int messageCount, int userId)
        {
            this.NotificationsCount = notificationCount;
            this.MessagesCount = messageCount;
            this.CustomUserId = userId;
        }

        public int Id { get; set; }

        public int NotificationsCount { get; set; }

        public int MessagesCount { get; set; }

        public int CustomUserId { get; set; }

        public virtual CustomUser User { get; set; }
    }
}
