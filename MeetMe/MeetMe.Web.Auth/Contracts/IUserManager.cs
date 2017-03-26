using System.Threading.Tasks;
using MeetMe.Data.Models;
using Microsoft.AspNet.Identity;

namespace MeetMe.Web.Auth.Contracts
{
    public interface IUserManager
    {
        Task<IdentityResult> CreateAsync(AspIdentityUser user, string password);

        Task<IdentityResult> AddToRoleAsync(string userId, string role);

        Task<IdentityResult> RemoveFromRoleAsync(string userId, string role);
    }
}
