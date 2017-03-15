using Bytes2you.Validation;
using MeetMe.Services.Contracts;
using MeetMe.Web.ViewModels.Navigation;
using System.Web.Mvc;

namespace MeetMe.Web.Controllers
{
    public class NavigationController : Controller
    {
        private readonly IStatisticService statisticService;
        private readonly IMapperService mapperService;

        public NavigationController(
            IStatisticService statisticService,
            IMapperService mapperService)
        {
            Guard.WhenArgument(statisticService, "StatisticService").IsNull().Throw();
            Guard.WhenArgument(mapperService, "MapperService").IsNull().Throw();

            this.statisticService = statisticService;
            this.mapperService = mapperService;
        }
        
        [HttpGet]
        [Authorize]
        public ActionResult Index(string id)
        {
            var statistic = this.statisticService.GetUserStatistic(id);
            var model = this.mapperService.MapObject<StatisticViewModel>(statistic);

            return this.PartialView("_IndexPartial", model);
        }

        // Ask why this is working
        [HttpPost]
        public ActionResult Index(string id, string useless)
        {
            var statistic = this.statisticService.GetUserStatistic(id);
            var model = this.mapperService.MapObject<StatisticViewModel>(statistic);

            return this.PartialView("_IndexPartial", model);
        }
    }
}