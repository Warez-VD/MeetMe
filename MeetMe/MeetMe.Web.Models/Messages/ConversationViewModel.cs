using System.Collections.Generic;
using MeetMe.Data.Models;
using MeetMe.Web.Models.Contracts;

namespace MeetMe.Web.Models.Messages
{
    public class ConversationViewModel : IMapFrom<Conversation>
    {
        public int Id { get; set; }

        public string FirstUserId { get; set; }

        public string SecondUserId { get; set; }

        public IList<MessageViewModel> Messages { get; set; }
    }
}
