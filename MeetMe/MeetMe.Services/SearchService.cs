using System.Collections.Generic;
using System.Linq;
using Bytes2you.Validation;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;

namespace MeetMe.Services
{
    public class SearchService : ISearchService
    {
        private readonly IEFRepository<CustomUser> userRepository;

        public SearchService(IEFRepository<CustomUser> userRepository)
        {
            Guard.WhenArgument(userRepository, "UserRepository").IsNull().Throw();

            this.userRepository = userRepository;
        }

        public IList<CustomUser> SearchedUsers(string pattern, int skip, int count)
        {
            var users = this.userRepository.All
                .Where(x => x.FullName.Contains(pattern))
                .OrderBy(x => x.Id)
                .Skip(skip)
                .Take(count)
                .ToList();

            return users;
        }
    }
}
