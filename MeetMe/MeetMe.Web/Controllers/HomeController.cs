﻿using Bytes2you.Validation;
using MeetMe.Services.Contracts;
using MeetMe.Web.Auth;
using MeetMe.Web.ViewModels.Home;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MeetMe.Web.Controllers
{
    public class HomeController : Controller
    {
        private const string DefaultProfileLogoPath = "~/Content/default-user.jpg";

        private readonly IAccountService accountService;
        private readonly IImageService imageService;
        private readonly IUserService userService;
        private readonly IMapperService mapperService;

        public HomeController(
            IAccountService accountService,
            IUserService userService,
            IImageService imageService,
            IMapperService mapperService)
        {
            Guard.WhenArgument(accountService, "AccountService").IsNull().Throw();
            Guard.WhenArgument(userService, "UserService").IsNull().Throw();
            Guard.WhenArgument(imageService, "ImageService").IsNull().Throw();
            // TODO: Guard mapper service

            this.accountService = accountService;
            this.userService = userService;
            this.imageService = imageService;
            this.mapperService = mapperService;
        }

        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            if (this.Request.IsAuthenticated)
            {
                string userId = this.HttpContext.User.Identity.GetUserId();
                var user = this.userService.GetById(userId);
                var profileImageUrl = this.imageService.ByteArrayToImageUrl(user.ProfileImage.Content);

                model.PersonalInfo = this.mapperService.MapObject<PersonalInfoViewModel>(user);
                model.PersonalInfo.ProfileImageUrl = profileImageUrl;

                // TODO: Get real publications
                model.Publications = new List<PublicationViewModel>()
                    {
                        new PublicationViewModel()
                        {
                            Author = "Test author"
                        }
                    };
            }

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        public ActionResult AddPublication(string some)
        {
            var model = new List<PublicationViewModel>()
            {
                new PublicationViewModel()
                {
                    Author = some
                }
            };

            return PartialView("_PublicationPartial", model);
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
            if (ModelState.IsValid)
            {
                var user = this.accountService.CreateUser(model.Register.Email, model.Register.Email);
                var result = await this.UserManager.CreateAsync(user, model.Register.Password);
                if (result.Succeeded)
                {
                    string profileLogoFullPath = Server.MapPath(DefaultProfileLogoPath);
                    this.accountService.Register(model.Register.FirstName, model.Register.LastName, user.Id, profileLogoFullPath);
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
            var user = this.userService.GetById(id);
            var profileImageUrl = this.imageService.ByteArrayToImageUrl(user.ProfileImage.Content);
            var model = this.mapperService.MapObject<ProfilePartialViewModel>(user);
            model.ProfileImageUrl = profileImageUrl;

            return this.PartialView("_ProfilePartial", model);
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return this.HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                this.ModelState.AddModelError("", error);
            }
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