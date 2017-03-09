using MeetMe.Data.Models;
using MeetMe.Web.ViewModels.Contracts;

namespace MeetMe.Web.ViewModels.Home
{
    public class ProfilePartialViewModel : IMapFrom<CustomUser>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ProfileImageUrl { get; set; }
    }
}