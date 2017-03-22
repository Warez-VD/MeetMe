using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Bytes2you.Validation;
using MeetMe.Services.Contracts;
using MeetMe.Web.Auth;
using MeetMe.Web.Models.Home;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace MeetMe.Web.Controllers
{
    public class HomeController : Controller
    {
        private const string DefaultProfileLogoPath = "~/Content/default-user.jpg";

        private readonly IAccountService accountService;
        private readonly IUserService userService;
        private readonly IStatisticService statisticService;
        private readonly IViewModelService viewModelService;

        public HomeController(
            IAccountService accountService,
            IUserService userService,
            IStatisticService statisticService,
            IViewModelService viewModelService)
        {
            Guard.WhenArgument(accountService, "AccountService").IsNull().Throw();
            Guard.WhenArgument(userService, "UserService").IsNull().Throw();
            Guard.WhenArgument(statisticService, "StatisticService").IsNull().Throw();
            Guard.WhenArgument(viewModelService, "ViewModelService").IsNull().Throw();

            this.accountService = accountService;
            this.userService = userService;
            this.statisticService = statisticService;
            this.viewModelService = viewModelService;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return this.HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return this.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return this.HttpContext.GetOwinContext().Authentication;
            }
        }

        [HttpGet]
        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            if (this.Request.IsAuthenticated)
            {
                string userId = this.HttpContext.User.Identity.GetUserId();
                var user = this.userService.GetByIndentityId(userId);
                model.PersonalInfo = this.viewModelService.GetMappedPersonalInfo(user);
            }

            return this.View(model);
        }

        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return this.View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(HomeViewModel model, string returnUrl)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View("Index", model);
            }

            var result = await this.SignInManager.PasswordSignInAsync(model.Login.Email, model.Login.Password, true, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return this.RedirectToLocal(returnUrl);
                case SignInStatus.Failure:
                default:
                    this.ModelState.AddModelError("Login.ShowServerError", "Invalid username or password");
                    return this.View("Index", model);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(HomeViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var user = this.accountService.CreateUser(model.Register.Email, model.Register.Email);
                var result = await this.UserManager.CreateAsync(user, model.Register.Password);
                if (result.Succeeded)
                {
                    string profileLogoFullPath = Server.MapPath(DefaultProfileLogoPath);
                    this.accountService.Register(model.Register.FirstName, model.Register.LastName, user.Id, profileLogoFullPath);
                    this.statisticService.CreateStatistic(user.Id);
                    await this.SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    return this.RedirectToAction("Index", "Home");
                }

                this.ModelState.AddModelError("Register.ShowServerError", "User with this email already exists");
            }

            return this.View("Index", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            this.AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return this.RedirectToAction("Index", "Home");
        }

        [ChildActionOnly]
        public ActionResult ProfilePartial()
        {
            string id = this.HttpContext.User.Identity.GetUserId();
            var user = this.userService.GetByIndentityId(id);
            var model = this.viewModelService.GetMappedProfilePartial(user);

            return this.PartialView("_ProfilePartial", model);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (this.Url.IsLocalUrl(returnUrl))
            {
                return this.Redirect(returnUrl);
            }

            return this.RedirectToAction("Index", "Home");
        }
    }
}