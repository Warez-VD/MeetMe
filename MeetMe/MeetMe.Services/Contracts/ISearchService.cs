using MeetMe.Web.Models.Search;
using System.Collections.Generic;

namespace MeetMe.Services.Contracts
{
    public interface ISearchService
    {
        IEnumerable<SearchUserViewModel> SearchedUsers(string pattern, int skip, int count);
    }
}
