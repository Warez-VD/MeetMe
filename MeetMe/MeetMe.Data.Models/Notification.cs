using System;
using System.ComponentModel.DataAnnotations;

namespace MeetMe.Data.Models
{
    public class Notification
    {
        public Notification() {}

        public Notification(int userId, string content, DateTime createdOn, bool isFriendship, int targetId)
            : this()
        {
            this.CustomUserId = userId;
            this.Content = content;
            this.CreatedOn = createdOn;
            this.IsFriendship = isFriendship;
            this.TargetUserId = targetId;
        }

        public int Id { get; set; }

        public int CustomUserId { get; set; }

        public virtual CustomUser User { get; set; }

        public int TargetUserId { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsFriendship { get; set; }

        [MaxLength(150)]
        public string Content { get; set; }

        public bool IsDeleted { get; set; }
    }
}
