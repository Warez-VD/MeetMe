using System.Collections.Generic;
using MeetMe.Data.Models;

namespace MeetMe.Services.Contracts
{
    public interface ISearchService
    {
        IList<CustomUser> SearchedUsers(string pattern, int skip, int count);
    }
}
