using System.Collections.Generic;

namespace MeetMe.Data.Models
{
    public class UserImage
    {
        public UserImage()
        {
            this.Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        public byte[] Content { get; set; }

        public bool IsDeleted { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
