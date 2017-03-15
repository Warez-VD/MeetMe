using System.Collections.Generic;

namespace MeetMe.Web.ViewModels.Search
{
    public class SearchViewModel
    {
        public IEnumerable<SearchUserViewModel> FoundUsers { get; set; }

        public int ResultsCount { get; set; }

        public string SearchedPattern { get; set; }
    }
}