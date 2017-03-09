using MeetMe.Data.Models;

namespace MeetMe.Services.Contracts
{
    public interface IUserService
    {
        CustomUser GetByIndentityId(string id);
    }
}
