using MeetMe.Data.Models;

namespace MeetMe.Services.Contracts
{
    public interface IUserFactory
    {
        User CreateUser(string firstName, string lastName, string aspIdentityUserId);
    }
}
