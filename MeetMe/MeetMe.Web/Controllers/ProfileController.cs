using System.Web.Mvc;
using Bytes2you.Validation;
using MeetMe.Services.Contracts;
using MeetMe.Web.Models.Profile;

namespace MeetMe.Web.Controllers
{
    public class ProfileController : Controller
    {
        private const string UpdatePersonalInformationError = "Something went wrong, please try again";
        private const string UpdatePersonalInformationSuccess = "Successfully updated personal info";

        private readonly IAccountService accountService;
        private readonly IUserService userService;
        private readonly IFriendService friendService;
        private readonly IViewModelService viewModelService;

        public ProfileController(
            IAccountService accountService,
            IUserService userService,
            IFriendService friendService,
            IViewModelService viewModelService)
        {
            Guard.WhenArgument(accountService, "AccountService").IsNull().Throw();
            Guard.WhenArgument(userService, "UserService").IsNull().Throw();
            Guard.WhenArgument(friendService, "FriendService").IsNull().Throw();
            Guard.WhenArgument(viewModelService, "ViewModelService").IsNull().Throw();

            this.accountService = accountService;
            this.userService = userService;
            this.friendService = friendService;
            this.viewModelService = viewModelService;
        }

        [HttpGet]
        public ActionResult Index(int id)
        {
            var user = this.userService.GetById(id);
            var friends = this.friendService.GetAllUserFriends(user.Id);
            var model = this.viewModelService.GetMappedProfile(user);
            var mappedFriends = this.viewModelService.GetMappedUserFriends(friends);
            model.Friends = mappedFriends;

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProfilePersonalnfo model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.PartialView("_ProfilePersonalInfoPartial", model);
            }

            var updatedUser = this.accountService.EditProfile(model);
            var updatedModel = this.viewModelService.GetMappedProfilePersonalInfo(updatedUser);
            return this.PartialView("_ProfilePersonalInfoPartial", updatedModel);
        }

        [HttpPost]
        public ActionResult ChangeProfileImage(int id)
        {
            string result = string.Empty;

            foreach (string file in Request.Files)
            {
                var fileContent = Request.Files[file];
                if (fileContent.ContentType == "image/jpeg" || fileContent.ContentType == "image/png")
                {
                    if (fileContent.ContentLength < 1000000)
                    {
                        this.accountService.ChangeProfileImage(fileContent.InputStream, id);
                        result = "Profile image successfully changed.Please, refresh";
                    }
                    else
                    {
                        result = "This image is too big";
                    }
                }
                else
                {
                    result = "Invalid content type, please add image";
                }
            }

            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult RemoveFriend(int id, string userId)
        {
            var user = this.userService.GetByIndentityId(userId);
            this.friendService.RemoveFriend(user.Id, id);

            var friends = this.friendService.GetAllUserFriends(user.Id);
            var model = this.viewModelService.GetMappedProfile(user);
            var mappedFriends = this.viewModelService.GetMappedUserFriends(friends);
            model.Friends = mappedFriends;

            return this.PartialView("_ProfileFriendsPartial", model);
        }
    }
}