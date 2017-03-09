using Bytes2you.Validation;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using System.Linq;

namespace MeetMe.Services
{
    public class UserService : IUserService
    {
        private readonly IEFRepository<CustomUser> userRepository;

        public UserService(IEFRepository<CustomUser> userRepository)
        {
            Guard.WhenArgument(userRepository, "UserRepository").IsNull().Throw();

            this.userRepository = userRepository;
        }

        public CustomUser GetByIndentityId(string id)
        {
            var user = this.userRepository
                .All
                .Where(x => x.AspIdentityUserId == id)
                .FirstOrDefault();

            return user;
        }
    }
}
