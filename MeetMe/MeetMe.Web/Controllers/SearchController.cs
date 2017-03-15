using MeetMe.Web.ViewModels.Search;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MeetMe.Web.Controllers
{
    public class SearchController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var model = new SearchViewModel();
            model.SearchedPattern = string.Empty;
            model.ResultsCount = 12;
            model.FoundUsers = new List<SearchUserViewModel>()
            {
                new SearchUserViewModel() { Id = 1, FullName = "John Smith", ImageUrl = "nqma", IsFriend = false },
                new SearchUserViewModel() { Id = 2, FullName = "John Tarantino", ImageUrl = "nqma", IsFriend = true }
            };

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Index(string pattern)
        {
            var model = new SearchViewModel();
            model.SearchedPattern = pattern;
            model.ResultsCount = 1;
            model.FoundUsers = new List<SearchUserViewModel>()
            {
                new SearchUserViewModel() { Id = 1, FullName = "John Smith", ImageUrl = "nqma", IsFriend = false }
            };

            return this.View(model);
        }
    }
}