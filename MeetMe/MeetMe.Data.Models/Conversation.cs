using System.Collections.Generic;

namespace MeetMe.Data.Models
{
    public class Conversation
    {
        private ICollection<Message> messages;

        public Conversation()
        {
            this.messages = new HashSet<Message>();
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

        public virtual ICollection<Message> Messages
        {
            get { return this.messages; }
            set { this.messages = value; }
        }
    }
}
