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

        public MessageController(
            IUserService userService,
            IViewModelService viewModelService,
            IFriendService friendService)
        {
            Guard.WhenArgument(userService, "UserService").IsNull().Throw();
            Guard.WhenArgument(viewModelService, "ViewModelService").IsNull().Throw();
            Guard.WhenArgument(friendService, "FriendService").IsNull().Throw();

            this.userService = userService;
            this.viewModelService = viewModelService;
            this.friendService = friendService;
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
    }
}