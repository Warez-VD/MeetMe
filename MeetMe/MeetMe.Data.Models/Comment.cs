using System;
using System.Collections.Generic;

namespace MeetMe.Data.Models
{
    public class Comment
    {
        public Comment()
        {
            this.Answers = new HashSet<Comment>();
        }

        public int Id { get; set; }

        public int CustomUserId { get; set; }

        public virtual CustomUser Author { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }
        
        public virtual ICollection<Comment> Answers { get; set; }
    }
}
