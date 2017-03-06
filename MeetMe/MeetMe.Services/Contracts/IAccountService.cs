using MeetMe.Data.Models;

namespace MeetMe.Services.Contracts
{
    public interface IAccountService
    {
        AspIdentityUser CreateUser(string username, string email);

        void Register(string firstName, string lastName, string id);
    }
}
