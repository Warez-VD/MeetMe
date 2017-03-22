using MeetMe.Data.Models;
using MeetMe.Web.Models.Contracts;

namespace MeetMe.Web.Models.Profile
{
    public class ProfileFriendViewModel : IMapFrom<CustomUser>
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string ProfileImageUrl { get; set; }
    }
}
