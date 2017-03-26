using System.Threading.Tasks;
using Bytes2you.Validation;
using MeetMe.Services.Contracts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;

namespace MeetMe.Web.Hubs
{
    [Authorize]
    public class Chat : Hub
    {
        private readonly IConversationService conversationService;
        private readonly IUserService userService;
        private readonly IViewModelService viewModelService;

        public Chat(
            IConversationService conversationService,
            IUserService userService,
            IViewModelService viewModelService)
        {
            Guard.WhenArgument(conversationService, "ConversationService").IsNull().Throw();
            Guard.WhenArgument(userService, "UserService").IsNull().Throw();
            Guard.WhenArgument(viewModelService, "ViewModelService").IsNull().Throw();

            this.conversationService = conversationService;
            this.userService = userService;
            this.viewModelService = viewModelService;
        }

        public void SendMessage(string message, int id, string userId, string friendId)
        {
            var user = this.userService.GetByIndentityId(this.Context.User.Identity.GetUserId());
            var newMessage = this.conversationService.AddMessageToConversation(id, user, message);
            var mappedMessage = this.viewModelService.GetMappedMessage(newMessage);
            if (mappedMessage.AuthorId == userId)
            {
                mappedMessage.IsCurrentUserAuthor = true;
            }

            this.Clients.Group(userId).addMessage(mappedMessage);
            this.Clients.Group(friendId).addMessage(mappedMessage);
        }

        public override Task OnConnected()
        {
            if (this.Context.User.Identity.GetUserId() != null)
            {
                string userId = this.Context.User.Identity.GetUserId();
                this.Groups.Add(this.Context.ConnectionId, userId);
            }

            return base.OnConnected();
        }
    }
}