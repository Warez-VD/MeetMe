using System.Collections.Generic;
using MeetMe.Web.Models.Search;

namespace MeetMe.Services.Contracts
{
    public interface ISearchService
    {
        IEnumerable<SearchUserViewModel> SearchedUsers(string pattern, int skip, int count, string userId);
    }
}
