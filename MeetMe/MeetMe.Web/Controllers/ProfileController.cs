using System.Web.Mvc;
using Bytes2you.Validation;
using MeetMe.Services.Contracts;

namespace MeetMe.Web.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUserService userService;
        private readonly IFriendService friendService;
        private readonly IViewModelService viewModelService;

        public ProfileController(
            IUserService userService,
            IFriendService friendService,
            IViewModelService viewModelService)
        {
            Guard.WhenArgument(userService, "UserService").IsNull().Throw();
            Guard.WhenArgument(friendService, "FriendService").IsNull().Throw();
            Guard.WhenArgument(viewModelService, "ViewModelService").IsNull().Throw();

            this.userService = userService;
            this.friendService = friendService;
            this.viewModelService = viewModelService;
        }

        [HttpGet]
        public ActionResult Index(int id)
        {
            // TODO: if id is null

            var user = this.userService.GetById(id);
            var friends = this.friendService.GetAllUserFriends(user.Id);
            var model = this.viewModelService.GetMappedProfile(user);
            var mappedFriends = this.viewModelService.GetMappedUserFriends(friends);
            model.Friends = mappedFriends;

            return this.View(model);
        }
    }
}