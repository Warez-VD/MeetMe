using System.Collections.Generic;

namespace MeetMe.Data.Models
{
    public class ProfileImage
    {
        public ProfileImage()
        {
            this.Comments = new HashSet<Comment>();
        }

        public ProfileImage(byte[] content)
            : this()
        {
            this.Content = content;
        }

        public int Id { get; set; }

        public byte[] Content { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
