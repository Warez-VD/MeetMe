using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MeetMe.Data.Models
{
    public class AspIdentityUser : IdentityUser
    {
        public AspIdentityUser()
            : base()
        {
        }

        public AspIdentityUser(string username, string email)
            : this()
        {
            this.UserName = username;
            this.Email = email;
        }

        public ClaimsIdentity GenerateUserIdentity(UserManager<AspIdentityUser> manager)
        {
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AspIdentityUser> manager)
        {
            return Task.FromResult(this.GenerateUserIdentity(manager));
        }
    }
}
