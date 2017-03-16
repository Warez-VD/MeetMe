using MeetMe.Data.Models;
using MeetMe.Web.Models.Contracts;

namespace MeetMe.Web.Models.Home
{
    public class PersonalInfoViewModel : IMapFrom<CustomUser>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ProfileImageUrl { get; set; }

        public int Age { get; set; }

        public string City { get; set; }

        public string School { get; set; }

        public string Company { get; set; }
    }
}