using System.Linq;
using System.Web.Mvc;
using Bytes2you.Validation;
using MeetMe.Services.Contracts;
using MeetMe.Web.Models.Search;
using Microsoft.AspNet.Identity;

namespace MeetMe.Web.Controllers
{
    public class SearchController : Controller
    {
        private const int DefaultUsersSkip = 0;
        private const int DefaultUsersToShow = 5;

        private readonly ISearchService searchService;
        private readonly IViewModelService viewModelService;

        public SearchController(ISearchService searchService, IViewModelService viewModelService)
        {
            Guard.WhenArgument(searchService, "SearchService").IsNull().Throw();
            Guard.WhenArgument(viewModelService, "ViewModelService").IsNull().Throw();

            this.searchService = searchService;
            this.viewModelService = viewModelService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var userId = this.HttpContext.User.Identity.GetUserId();
            var results = this.searchService.SearchedUsers(string.Empty, DefaultUsersSkip, DefaultUsersToShow);
            var mappedUsers = this.viewModelService.GetMappedSearchedUsers(results, userId);
            var model = new SearchViewModel();
            model.SearchedPattern = string.Empty;
            model.ResultsCount = results.Count();
            model.FoundUsers = mappedUsers;

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string pattern, int skip, int count, string userId)
        {
            var results = this.searchService.SearchedUsers(pattern, skip, count);
            var mappedUsers = this.viewModelService.GetMappedSearchedUsers(results, userId);
            var model = new SearchViewModel();
            model.SearchedPattern = pattern;
            model.ResultsCount = results.Count();
            model.FoundUsers = mappedUsers;

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

            var results = this.searchService.SearchedUsers(pattern, skip, count);
            var model = this.viewModelService.GetMappedSearchedUsers(results, userId);

            return this.PartialView("_SearchResultsPartial", model);
        }
    }
}