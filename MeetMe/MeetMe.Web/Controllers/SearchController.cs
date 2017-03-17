using Bytes2you.Validation;
using MeetMe.Services.Contracts;
using MeetMe.Web.Models.Search;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MeetMe.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            Guard.WhenArgument(searchService, "SearchService").IsNull().Throw();

            this.searchService = searchService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var results = this.searchService.SearchedUsers(string.Empty, 0, 50);
            var model = new SearchViewModel();
            model.SearchedPattern = string.Empty;
            model.ResultsCount = results.Count();
            model.FoundUsers = results;

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