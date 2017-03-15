using MeetMe.Data.Models;
using System.Collections.Generic;

namespace MeetMe.Services.Contracts
{
    public interface IUserService
    {
        CustomUser GetByIndentityId(string id);

        IEnumerable<string> GetUsernames();
    }
}
