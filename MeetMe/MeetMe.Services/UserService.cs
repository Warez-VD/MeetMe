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
        private readonly IConversationService conversationService;

        public UserService(
            IEFRepository<CustomUser> userRepository,
            IFriendService friendService,
            IUnitOfWork unitOfWork,
            IConversationService conversationService)
        {
            Guard.WhenArgument(userRepository, "UserRepository").IsNull().Throw();
            Guard.WhenArgument(friendService, "FriendService").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "UnitOfWork").IsNull().Throw();
            Guard.WhenArgument(conversationService, "ConversationService").IsNull().Throw();

            this.userRepository = userRepository;
            this.friendService = friendService;
            this.unitOfWork = unitOfWork;
            this.conversationService = conversationService;
        }

        public void AddFriend(string userId, int friendId)
        {
            var user = this.GetByIndentityId(userId);
            var friendUser = this.userRepository.GetById(friendId);
            this.friendService.AddFriendship(user.Id, friendUser.AspIdentityUserId, friendId);
        }

        public void CreateConversation(string userId, int friendId)
        {
            var friendUser = this.userRepository.GetById(friendId);
            this.conversationService.CreateConversation(userId, friendUser.AspIdentityUserId);   
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

        public IEnumerable<CustomUser> GetAllUsers()
        {
            return this.userRepository.All.ToList();
        }

        public void BanUser(string userId)
        {
            var user = this.GetByIndentityId(userId);
            user.IsBanned = true;
            this.userRepository.Update(user);
            this.unitOfWork.Commit();
        }

        public void UnbanUser(string userId)
        {
            var user = this.GetByIndentityId(userId);
            user.IsBanned = false;
            this.userRepository.Update(user);
            this.unitOfWork.Commit();
        }
    }
}
