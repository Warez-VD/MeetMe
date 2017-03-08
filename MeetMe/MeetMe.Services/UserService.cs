using Bytes2you.Validation;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using System.Linq;

namespace MeetMe.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<CustomUser> userRepository;

        public UserService(IRepository<CustomUser> userRepository)
        {
            Guard.WhenArgument(userRepository, "UserRepository").IsNull().Throw();

            this.userRepository = userRepository;
        }

        public CustomUser GetById(string id)
        {
            var user = this.userRepository.All(x => x.AspIdentityUserId == id).FirstOrDefault();
            return user;
        }
    }
}
