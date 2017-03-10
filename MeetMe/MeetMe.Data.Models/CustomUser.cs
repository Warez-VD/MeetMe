using System.Collections.Generic;

namespace MeetMe.Data.Models
{
    public class CustomUser
    {
        public CustomUser()
        {
            this.Images = new HashSet<UserImage>();
            this.Friends = new HashSet<CustomUser>();
            this.Publications = new HashSet<Publication>();
        }

        public CustomUser(string firstName, string lastName, string aspIdentityUserId, ProfileImage profileLogo)
            : this()
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.AspIdentityUserId = aspIdentityUserId;
            this.ProfileImage = profileLogo;
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AspIdentityUserId { get; set; }

        public int Age { get; set; }

        public string City { get; set; }

        public string School { get; set; }

        public string Company { get; set; }

        public int ProfileImageId { get; set; }

        public virtual ProfileImage ProfileImage { get; set; }

        public virtual ICollection<UserImage> Images { get; set; }

        public virtual ICollection<CustomUser> Friends { get; set; }

        public virtual ICollection<Publication> Publications { get; set; }
    }
}
