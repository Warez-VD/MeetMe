using MeetMe.Data.Models;

namespace MeetMe.Services.Contracts
{
    public interface IUserService
    {
        CustomUser GetById(string id);
    }
}
