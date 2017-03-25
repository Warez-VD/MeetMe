using System.Collections.Generic;
using MeetMe.Web.Models.Profile;

namespace MeetMe.Web.Models.Messages
{
    public class MessageIndexViewModel
    {
        public IList<ProfileFriendViewModel> Friends { get; set; }

        public IList<ConversationViewModel> Conversations { get; set; }
    }
}
