using System;
using System.Collections.Generic;
using System.Linq;
using Bytes2you.Validation;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;

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

        public void AddFriendship(int userId, string friendIdentityId, int friendId)
        {
            var userFriend = this.userFriendFactory.CreateUserFriend(userId, friendIdentityId, friendId);
            this.userFriendRepository.Add(userFriend);
            this.unitOfWork.Commit();
        }

        // TODO: unit test
        public ICollection<CustomUser> GetAllUserFriends(int id)
        {
            var friendIds = this.GetAllUserFriendsIds(id);
            var result = new List<CustomUser>();

            foreach (var friendId in friendIds)
            {
                var friend = this.userRepository.GetById(friendId);
                result.Add(friend);
            }

            return result;
        }

        public ICollection<int> GetAllUserFriendsIds(int id)
        {
            var friendIds = this.userFriendRepository.All
                .Where(x => x.UserId == id)
                .Select(x => x.FriendId)
                .ToList();

            return friendIds;
        }

        public UserFriend GetFriendShip(int currentUserId, int friendId)
        {
            var friendship = this.userFriendRepository
                .All
                .Where((x => x.UserId == currentUserId && x.FriendId == friendId))
                .FirstOrDefault();

            return friendship;
        }

        public void RemoveFriend(int currentUserId, int friendId)
        {
            var friendship = this.GetFriendShip(currentUserId, friendId);
            var friendshipReverse = this.GetFriendShip(friendId, currentUserId);
            this.userFriendRepository.Delete(friendship);
            this.userFriendRepository.Delete(friendshipReverse);
            this.unitOfWork.Commit();
        }
    }
}
