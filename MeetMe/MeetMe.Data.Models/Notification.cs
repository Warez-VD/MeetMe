using System;
using System.ComponentModel.DataAnnotations;

namespace MeetMe.Data.Models
{
    public class Notification
    {
        public Notification() {}

        public Notification(int userId, string content, DateTime createdOn, bool isFriendship)
        {
            this.CustomUserId = userId;
            this.Content = content;
            this.CreatedOn = createdOn;
            this.IsFriendship = isFriendship;
        }

        public int Id { get; set; }

        public int CustomUserId { get; set; }

        public virtual CustomUser User { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsFriendship { get; set; }

        // TODO: Mark as read

        [MaxLength(150)]
        public string Content { get; set; }

        public bool IsDeleted { get; set; }
    }
}
