using MeetMe.Data.Models;

namespace MeetMe.Services.Contracts
{
    public interface IConversationService
    {
        void CreateConversation(string userId, string friendId);

        Conversation GetByUserId(string userId);

        Message AddMessageToConversation(CustomUser user, string userId, string content);
    }
}
