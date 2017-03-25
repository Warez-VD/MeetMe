using System.Collections.Generic;
using MeetMe.Data.Models;
using MeetMe.Web.Models.Contracts;

namespace MeetMe.Web.Models.Messages
{
    public class ConversationViewModel : IMapFrom<Conversation>
    {
        public string FirstUserId { get; set; }

        public string SecondUserId { get; set; }

        public ICollection<MessageViewModel> Messages { get; set; }
    }
}
