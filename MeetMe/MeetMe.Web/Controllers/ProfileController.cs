using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using MeetMe.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeetMe.Web.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IMapperService mapperService;

        public ProfileController(IMapperService mapperService)
        {
            this.mapperService = mapperService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = new UserViewModel()
            {
                FirstName = "Smith"
            };

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Index(UserViewModel user)
        {
            if (this.ModelState.IsValid)
            {
                var mapped = this.mapperService.MapObject<CustomUser>(user);
            }

            return View(user);
        }
    }
}