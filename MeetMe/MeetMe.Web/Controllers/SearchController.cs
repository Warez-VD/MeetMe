using Bytes2you.Validation;
using MeetMe.Services.Contracts;
using MeetMe.Web.Models.Search;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace MeetMe.Web.Controllers
{
    public class SearchController : Controller
    {
        private const int DefaultUsersSkip = 0;
        private const int DefaultUsersToShow = 5;

        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            Guard.WhenArgument(searchService, "SearchService").IsNull().Throw();

            this.searchService = searchService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var userId = this.HttpContext.User.Identity.GetUserId();
            var results = this.searchService.SearchedUsers(string.Empty, DefaultUsersSkip, DefaultUsersToShow, userId);
            var model = new SearchViewModel();
            model.SearchedPattern = string.Empty;
            model.ResultsCount = results.Count();
            model.FoundUsers = results;

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string pattern, int skip, int count, string userId)
        {
            var results = this.searchService.SearchedUsers(pattern, skip, count, userId);
            var model = new SearchViewModel();
            model.SearchedPattern = pattern;
            model.ResultsCount = results.Count();
            model.FoundUsers = results;

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ShowMoreResults(string pattern, int skip, int count, string userId)
        {
            if (pattern == null)
            {
                pattern = string.Empty;
            }

            var results = this.searchService.SearchedUsers(pattern, skip, count, userId);

            return this.PartialView("_SearchResultsPartial", results);
        }
    }
}