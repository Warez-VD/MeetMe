using System.Web.Mvc;
using Bytes2you.Validation;
using MeetMe.Services.Contracts;
using MeetMe.Web.Auth.Contracts;

namespace MeetMe.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IUserService userService;
        private readonly IViewModelService viewModelService;
        private readonly IUserManager userManager;

        public AdminController(
            IUserService userService,
            IViewModelService viewModelService,
            IUserManager userManager)
        {
            Guard.WhenArgument(userService, "UserService").IsNull().Throw();
            Guard.WhenArgument(viewModelService, "ViewModelService").IsNull().Throw();
            Guard.WhenArgument(userManager, "UserManager").IsNull().Throw();

            this.userService = userService;
            this.viewModelService = viewModelService;
            this.userManager = userManager;
        }
        
        [HttpGet]
        public ActionResult Index()
        {
            var users = this.userService.GetAllUsers();
            var model = this.viewModelService.GetMappedAdminUsers(users);
            return this.View(model);
        }

        [HttpPost]
        public ActionResult BanUser(string id)
        {
            this.userManager.AddToRoleAsync(id, "banned");

            this.userService.BanUser(id);

            string successMessage = "User banned successfully";
            return this.Json(successMessage);
        }

        [HttpPost]
        public ActionResult UnbanUser(string id)
        {
            this.userManager.RemoveFromRoleAsync(id, "banned");
            this.userService.UnbanUser(id);

            string successMessage = "User unbanned successfully";
            return this.Json(successMessage);
        }
    }
}