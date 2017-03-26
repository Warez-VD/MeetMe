using System.Threading.Tasks;
using MeetMe.Data.Models;
using Microsoft.AspNet.Identity.Owin;

namespace MeetMe.Web.Auth.Contracts
{
    public interface ISignInManager
    {
        Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool isPersistent, bool shouldLockout);
        
        Task SignInAsync(AspIdentityUser user, bool isPersistent, bool rememberBrowser);
    }
}
