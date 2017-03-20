using System.Web.Mvc;
using MeetMe.Services.Contracts;

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