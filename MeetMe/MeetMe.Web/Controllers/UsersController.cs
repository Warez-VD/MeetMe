using System.Web.Mvc;
using Bytes2you.Validation;
using MeetMe.Services.Contracts;

namespace MeetMe.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            Guard.WhenArgument(userService, "UserService").IsNull().Throw();

            this.userService = userService;
        }

        [HttpGet]
        public ActionResult Usernames()
        {
            var usernames = this.userService.GetUsernames();

            return this.Json(usernames, JsonRequestBehavior.AllowGet);
        }
    }
}