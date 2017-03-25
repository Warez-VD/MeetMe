using System;
using System.ComponentModel.DataAnnotations;

namespace MeetMe.Data.Models
{
    public class Message
    {
        public Message()
        {
        }

        public Message(string content, CustomUser user, DateTime createdOn)
        {
            this.Content = content;
            this.User = user;
            this.CreatedOn = createdOn;
        }

        public int Id { get; set; }

        [MaxLength(200)]
        public string Content { get; set; }

        public int CustomUserId { get; set; }

        public virtual CustomUser User { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
