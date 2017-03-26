using System.Collections.Generic;
using MeetMe.Data.Models;

namespace MeetMe.Services.Contracts
{
    public interface IConversationService
    {
        void CreateConversation(string userId, string friendId);

        Conversation GetByUserId(string userId);

        Conversation GetById(int id);

        IEnumerable<Conversation> GetAllByUserId(string userId);

        Message AddMessageToConversation(int id, CustomUser user, string content);
    }
}
