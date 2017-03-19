using MeetMe.Data.Models;
using System.Collections.Generic;

namespace MeetMe.Services.Contracts
{
    public interface IFriendService
    {
        ICollection<CustomUser> GetAllUserFriends(int id);

        IEnumerable<int> GetAllUserFriendsIds(int id);

        void AddFriendship(int userId, string friendIdentityId, int friendId);
    }
}
