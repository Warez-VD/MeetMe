using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeetMe.Data.Models
{
    public class CustomUser
    {
        public CustomUser()
        {
            this.Images = new HashSet<UserImage>();
            this.Publications = new HashSet<Publication>();
        }

        public CustomUser(string firstName, string lastName, string fullname, string aspIdentityUserId, ProfileImage profileLogo)
            : this()
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FullName = fullname;
            this.AspIdentityUserId = aspIdentityUserId;
            this.ProfileImage = profileLogo;
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string LastName { get; set; }

        public string FullName { get; set; }

        public string AspIdentityUserId { get; set; }
        
        public int Age { get; set; }

        [MaxLength(100)]
        public string City { get; set; }

        [MaxLength(100)]
        public string School { get; set; }

        [MaxLength(100)]
        public string Company { get; set; }

        public int ProfileImageId { get; set; }

        public virtual ProfileImage ProfileImage { get; set; }

        public virtual ICollection<UserImage> Images { get; set; }

        public virtual ICollection<Publication> Publications { get; set; }
    }
}
