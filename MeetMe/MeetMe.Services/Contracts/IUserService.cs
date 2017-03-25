using System.Collections.Generic;
using MeetMe.Data.Models;

namespace MeetMe.Services.Contracts
{
    public interface IUserService
    {
        CustomUser GetById(int id);

        CustomUser GetByIndentityId(string id);

        IEnumerable<string> GetUsernames();

        IEnumerable<CustomUser> GetAllUsers();

        void AddFriend(string userId, int friendId);

        void CreateConversation(string userId, int friendId);

        void BanUser(string userId);

        void UnbanUser(string userId);
    }
}
