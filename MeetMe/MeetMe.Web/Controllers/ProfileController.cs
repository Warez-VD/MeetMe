using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeetMe.Web.Controllers
{
    [Authorize]
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
            return this.View();
        }
    }
}