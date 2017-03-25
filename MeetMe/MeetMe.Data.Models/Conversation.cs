using System.Collections.Generic;

namespace MeetMe.Data.Models
{
    public class Conversation
    {
        public Conversation()
        {
            this.Messages = new HashSet<Message>();
        }

        public Conversation(string firstUserId, string secondUserId)
            : this()
        {
            this.FirstUserId = firstUserId;
            this.SecondUserId = secondUserId;
        }

        public int Id { get; set; }

        public string FirstUserId { get; set; }

        public string SecondUserId { get; set; }

        public ICollection<Message> Messages { get; set; }
    }
}
