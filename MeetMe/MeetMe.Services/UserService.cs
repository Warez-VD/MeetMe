using System.Collections.Generic;
using System.Linq;
using Bytes2you.Validation;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;

namespace MeetMe.Services
{
    public class UserService : IUserService
    {
        private readonly IEFRepository<CustomUser> userRepository;
        private readonly IFriendService friendService;
        private readonly IUnitOfWork unitOfWork;

        public UserService(
            IEFRepository<CustomUser> userRepository,
            IFriendService friendService,
            IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(userRepository, "UserRepository").IsNull().Throw();
            Guard.WhenArgument(friendService, "FriendService").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "UnitOfWork").IsNull().Throw();
            
            this.userRepository = userRepository;
            this.friendService = friendService;
            this.unitOfWork = unitOfWork;
        }

        public void AddFriend(string userId, int friendId)
        {
            var user = this.GetByIndentityId(userId);
            var friendUser = this.userRepository.GetById(friendId);
            this.friendService.AddFriendship(user.Id, friendUser.AspIdentityUserId, friendId);
        }

        public CustomUser GetById(int id)
        {
            var user = this.userRepository.GetById(id);
            return user;
        }

        public CustomUser GetByIndentityId(string id)
        {
            var user = this.userRepository
                .All
                .Where(x => x.AspIdentityUserId == id)
                .FirstOrDefault();

            return user;
        }

        public IEnumerable<string> GetUsernames()
        {
            var usernames = this.userRepository.All
                .ToList()
                .Select(x => x.FullName);

            return usernames;
        }
    }
}
