using MeetMe.Web.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeetMe.Web.Controllers
{
    public class PublicationController : Controller
    {
        public ActionResult Publications()
        {
            var model = new List<PublicationViewModel>()
            {
                new PublicationViewModel() {  Author = "Someone" }
            };

            return this.PartialView("_PublicationPartial", model);
        }

        [HttpPost]
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
    }
}