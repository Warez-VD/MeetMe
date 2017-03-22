using System.Web.Mvc;

namespace MeetMe.Web.Areas.Administration.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}