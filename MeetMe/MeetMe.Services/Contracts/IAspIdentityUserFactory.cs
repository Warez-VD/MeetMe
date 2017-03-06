using MeetMe.Data.Models;

namespace MeetMe.Services.Contracts
{
    public interface IAspIdentityUserFactory
    {
        AspIdentityUser CreateAspIdentityUser(string username, string email);
    }
}
