using MeetMe.Services.Contracts;
using System.Collections.Generic;
using System.Linq;
using MeetMe.Data.Models;
using MeetMe.Data.Contracts;
using Bytes2you.Validation;
using System;

namespace MeetMe.Services
{
    public class FriendService : IFriendService
    {
        private readonly IEFRepository<UserFriend> userFriendRepository;
        private readonly IEFRepository<CustomUser> userRepository;
        private readonly IUserFriendFactory userFriendFactory;
        private readonly IUnitOfWork unitOfWork;

        public FriendService(
            IEFRepository<UserFriend> userFriendRepository,
            IEFRepository<CustomUser> userRepository,
            IUserFriendFactory userFriendFactory,
            IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(userFriendRepository, "UserFriendRepository").IsNull().Throw();
            Guard.WhenArgument(userRepository, "UserRepository").IsNull().Throw();
            Guard.WhenArgument(userFriendFactory, "UserFriendFactory").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "UnitOfWork").IsNull().Throw();

            this.userFriendRepository = userFriendRepository;
            this.userRepository = userRepository;
            this.userFriendFactory = userFriendFactory;
            this.unitOfWork = unitOfWork;
        }

        public void AddFriendship(int userId, int friendId)
        {
            var userFriend = this.userFriendFactory.CreateUserFriend(userId, friendId);
            this.userFriendRepository.Add(userFriend);
            this.unitOfWork.Commit();
        }

        public ICollection<CustomUser> GetAllUserFriends(int id)
        {
            var friendIds = this.userFriendRepository.All
                .Where(x => x.UserId == id)
                .Select(x => x.FriendId)
                .ToList();
            var result = new List<CustomUser>();

            foreach (var friendId in friendIds)
            {
                var friend = this.userRepository.GetById(friendId);
                result.Add(friend);
            }

            return result;
        }

        public IEnumerable<int> GetAllUserFriendsIds(int id)
        {
            var friendIds = this.userFriendRepository.All
                .Where(x => x.UserId == id)
                .Select(x => x.FriendId)
                .ToList();

            return friendIds;
        }
    }
}
