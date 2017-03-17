using MeetMe.Data.Models;

namespace MeetMe.Services.Contracts
{
    public interface ICustomUserFactory
    {
        CustomUser CreateCustomUser(string firstName, string lastName, string fullname, string aspIdentityUserId, ProfileImage profileLogo);
    }
}
