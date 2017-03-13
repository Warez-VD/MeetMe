using System;
using System.ComponentModel.DataAnnotations;

namespace MeetMe.Data.Models
{
    public class Comment
    {
        public Comment() {}

        public Comment(string content, int userId, DateTime createdOn)
        {
            this.Content = content;
            this.CustomUserId = userId;
            this.CreatedOn = createdOn;
        }

        public int Id { get; set; }

        public int CustomUserId { get; set; }

        public virtual CustomUser Author { get; set; }
        
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
