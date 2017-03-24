using System.Web;
using System.Web.Mvc;
using Bytes2you.Validation;
using MeetMe.Web.Auth;
using MeetMe.Services.Contracts;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace MeetMe.Web.Areas.Administration.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IUserService userService;
        private readonly IViewModelService viewModelService;

        public DashboardController(IUserService userService, IViewModelService viewModelService)
        {
            Guard.WhenArgument(userService, "UserService").IsNull().Throw();
            Guard.WhenArgument(viewModelService, "ViewModelService").IsNull().Throw();

            this.userService = userService;
            this.viewModelService = viewModelService;
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
            var manager = this.Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            manager.AddToRole(id, "banned");
            this.userService.BanUser(id);

            string successMessage = "User banned successfully";
            return this.Json(successMessage);
        }

        [HttpPost]
        public ActionResult UnbanUser(string id)
        {
            var manager = this.Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            manager.RemoveFromRole(id, "banned");
            this.userService.UnbanUser(id);

            string successMessage = "User unbanned successfully";
            return this.Json(successMessage);
        }
    }
}