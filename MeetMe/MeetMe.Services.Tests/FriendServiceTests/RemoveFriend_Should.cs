using System.Collections.Generic;
using System.Linq;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace MeetMe.Services.Tests.FriendServiceTests
{
    [TestFixture]
    public class RemoveFriend_Should
    {
        [Test]
        public void CallUserFriendRepository_Delete()
        {
            // Arrange
            int currentUserId = 1;
            int friendId = 3;

            var mockedUserFriendRepository = new Mock<IEFRepository<UserFriend>>();
            var friendships = new List<UserFriend>()
            {
                new UserFriend() { UserId = currentUserId, FriendId = friendId },
                new UserFriend() { UserId = friendId, FriendId = currentUserId }
            }.AsQueryable();
            mockedUserFriendRepository.Setup(x => x.All).Returns(friendships);
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var mockedUserFriendFactory = new Mock<IUserFriendFactory>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var friendService = new FriendService(
                mockedUserFriendRepository.Object,
                mockedUserRepository.Object,
                mockedUserFriendFactory.Object,
                mockedUnitOfWork.Object);

            // Act
            friendService.RemoveFriend(currentUserId, friendId);

            // Assert
            mockedUserFriendRepository.Verify(x => x.Delete(It.Is<UserFriend>(u => u.UserId == currentUserId && u.FriendId == friendId)));
            mockedUserFriendRepository.Verify(x => x.Delete(It.Is<UserFriend>(u => u.UserId == friendId && u.FriendId == currentUserId)));
        }

        [Test]
        public void CallUnitOfWork_CommitOnce()
        {
            // Arrange
            int currentUserId = 1;
            int friendId = 3;

            var mockedUserFriendRepository = new Mock<IEFRepository<UserFriend>>();
            var friendships = new List<UserFriend>()
            {
                new UserFriend() { UserId = currentUserId, FriendId = friendId },
                new UserFriend() { UserId = friendId, FriendId = currentUserId }
            }.AsQueryable();
            mockedUserFriendRepository.Setup(x => x.All).Returns(friendships);
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var mockedUserFriendFactory = new Mock<IUserFriendFactory>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var friendService = new FriendService(
                mockedUserFriendRepository.Object,
                mockedUserRepository.Object,
                mockedUserFriendFactory.Object,
                mockedUnitOfWork.Object);

            // Act
            friendService.RemoveFriend(currentUserId, friendId);

            // Assert
            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}
