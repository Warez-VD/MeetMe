using System.Collections.Generic;
using MeetMe.Data.Models;
using MeetMe.Web.Models.Contracts;

namespace MeetMe.Web.Models.Profile
{
    public class ProfileViewModel : IMapFrom<CustomUser>
    {
        public string AspIdentityUserId { get; set; }
        
        public string FullName { get; set; }

        public string ProfileImageUrl { get; set; }
        
        public ProfilePersonalnfo PersonalInfo { get; set; }

        public IEnumerable<ProfileFriendViewModel> Friends { get; set; }
    }
}
