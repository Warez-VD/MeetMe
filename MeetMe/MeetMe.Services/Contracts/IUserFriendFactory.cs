using MeetMe.Data.Models;

namespace MeetMe.Services.Contracts
{
    public interface IUserFriendFactory
    {
        UserFriend CreateUserFriend(int userId, int friendId);
    }
}
