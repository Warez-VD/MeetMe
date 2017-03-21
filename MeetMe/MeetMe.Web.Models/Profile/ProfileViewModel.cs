using System.Collections.Generic;
using MeetMe.Data.Models;
using MeetMe.Web.Models.Contracts;

namespace MeetMe.Web.Models.Profile
{
    public class ProfileViewModel : IMapFrom<CustomUser>
    {
        public string FullName { get; set; }

        public string ProfileImageUrl { get; set; }

        public int Age { get; set; }

        public string City { get; set; }

        public string School { get; set; }

        public string Company { get; set; }

        public IEnumerable<ProfileFriendViewModel> Friends { get; set; }
    }
}
