using MeetMe.Data.Models;

namespace MeetMe.Services.Contracts
{
    public interface IConversationService
    {
        void CreateConversation(string userId, string friendId);

        Conversation GetByUserAndFriendId(string userId, string friendId);
    }
}
