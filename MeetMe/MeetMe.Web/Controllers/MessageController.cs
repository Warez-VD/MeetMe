using Bytes2you.Validation;
using MeetMe.Services.Contracts;
using System.Web.Mvc;

namespace MeetMe.Web.Controllers
{
    public class MessageController : Controller
    {
        private readonly IUserService userService;
        private readonly IViewModelService viewModelService;
        private readonly IFriendService friendService;
        private readonly IConversationService conversationService;

        public MessageController(
            IUserService userService,
            IViewModelService viewModelService,
            IFriendService friendService,
            IConversationService conversationService)
        {
            Guard.WhenArgument(userService, "UserService").IsNull().Throw();
            Guard.WhenArgument(viewModelService, "ViewModelService").IsNull().Throw();
            Guard.WhenArgument(friendService, "FriendService").IsNull().Throw();
            Guard.WhenArgument(conversationService, "ConversationService").IsNull().Throw();

            this.userService = userService;
            this.viewModelService = viewModelService;
            this.friendService = friendService;
            this.conversationService = conversationService;
        }

        [HttpGet]
        public ActionResult Index(string id)
        {
            if (id == null)
            {
                return this.RedirectToAction("Index", "Home");
            }

            var user = this.userService.GetByIndentityId(id);
            var userFriends = this.friendService.GetAllUserFriends(user.Id);
            var model = this.viewModelService.GetMappedUserFriends(userFriends);

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Conversation(string id)
        {
            var conversation = this.conversationService.GetByUserId(id);
            var model = this.viewModelService.GetMappedConversation(conversation);

            return this.PartialView("_ConversationPartial", model);
        }
    }
}