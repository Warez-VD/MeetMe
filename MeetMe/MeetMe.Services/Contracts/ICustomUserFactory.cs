using MeetMe.Data.Models;

namespace MeetMe.Services.Contracts
{
    public interface ICustomUserFactory
    {
        CustomUser CreateCustomUser(string firstName, string lastName, string aspIdentityUserId, ProfileImage profileLogo);
    }
}
