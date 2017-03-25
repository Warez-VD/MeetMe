using MeetMe.Data.Models;

namespace MeetMe.Services.Contracts
{
    public interface IMessageService
    {
        Message CreateMessage(CustomUser user, string content);
    }
}
