using System.Collections.Generic;
using MeetMe.Data.Models;

namespace MeetMe.Services.Contracts
{
    public interface IFriendService
    {
        ICollection<CustomUser> GetAllUserFriends(int id);

        ICollection<int> GetAllUserFriendsIds(int id);

        void AddFriendship(int userId, string friendIdentityId, int friendId);

        void RemoveFriend(int currentUserId, int friendId);

        UserFriend GetFriendShip(int currentUserId, int friendId);
    }
}
