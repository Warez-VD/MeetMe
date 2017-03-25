using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.Identity;
using System;
using MeetMe.Services.Contracts;
using Bytes2you.Validation;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MeetMe.Web.Hubs
{
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

        public void SendMessage(string message, string userId, string friendId)
        {
            var user = this.userService.GetByIndentityId(userId);
            var newMessage = this.conversationService.AddMessageToConversation(user, userId, message);
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