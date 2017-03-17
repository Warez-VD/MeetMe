using System;
using System.ComponentModel.DataAnnotations;

namespace MeetMe.Data.Models
{
    public class Notification
    {
        public Notification(int userId, string content, DateTime createdOn)
        {
            this.CustomUserId = userId;
            this.Content = content;
            this.CreatedOn = createdOn;
        }

        public int Id { get; set; }

        public int CustomUserId { get; set; }

        public virtual CustomUser User { get; set; }

        public DateTime CreatedOn { get; set; }

        [MaxLength(150)]
        public string Content { get; set; }

        public bool IsDeleted { get; set; }
    }
}
