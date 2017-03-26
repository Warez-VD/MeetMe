using System.Web;
using MeetMe.Web.Helpers.Contracts;
using Microsoft.AspNet.Identity;

namespace MeetMe.Web.Helpers
{
    public class IdentityHelper : IIdentityHelper
    {
        public string GetCurrentUserId()
        {
            return HttpContext.Current.User.Identity.GetUserId();
        }
    }
}