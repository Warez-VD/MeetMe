using MeetMe.Data.Models;
using MeetMe.Web.Models.Contracts;

namespace MeetMe.Web.Models.Admin
{
    public class DashboardViewModel : IMapFrom<CustomUser>
    {
        public string AspIdentityUserId { get; set; }

        public string FullName { get; set; }

        public bool IsBanned { get; set; }
    }
}
