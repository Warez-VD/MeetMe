using MeetMe.Data.Models;

namespace MeetMe.Services.Contracts
{
    public interface IConversationFactory
    {
        Conversation CreateConversation(string firstUserId, string secondUserId);
    }
}
