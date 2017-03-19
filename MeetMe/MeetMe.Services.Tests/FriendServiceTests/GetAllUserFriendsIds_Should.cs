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
    public class GetAllUserFriendsIds_Should
    {
        [Test]
        public void ReturnCorrectFriendsIds()
        {
            // Arrange
            int userId = 10;
            var mockedUserFriendRepository = new Mock<IEFRepository<UserFriend>>();
            var friendShips = new List<UserFriend>()
            {
                new UserFriend() { UserId = userId, FriendId = 2 },
                new UserFriend() { UserId = 50, FriendId = 1 },
                new UserFriend() { UserId = userId, FriendId = 3 }
            }.AsQueryable();
            mockedUserFriendRepository.Setup(x => x.All).Returns(friendShips);
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var mockedUserFriendFactory = new Mock<IUserFriendFactory>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var friendService = new FriendService(
                mockedUserFriendRepository.Object,
                mockedUserRepository.Object,
                mockedUserFriendFactory.Object,
                mockedUnitOfWork.Object);
            var expected = new List<int>() { 2, 3 };

            // Act
            var result = friendService.GetAllUserFriendsIds(userId);

            // Assert
            CollectionAssert.AreEqual(result, expected);
        }

        [Test]
        public void ReturnEmptyCollection_IfNoFriends()
        {
            // Arrange
            int userId = 10;
            var mockedUserFriendRepository = new Mock<IEFRepository<UserFriend>>();
            var friendShips = new List<UserFriend>()
            {
                new UserFriend() { UserId = 14, FriendId = 2 },
                new UserFriend() { UserId = 50, FriendId = 1 },
                new UserFriend() { UserId = 45, FriendId = 3 }
            }.AsQueryable();
            mockedUserFriendRepository.Setup(x => x.All).Returns(friendShips);
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var mockedUserFriendFactory = new Mock<IUserFriendFactory>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var friendService = new FriendService(
                mockedUserFriendRepository.Object,
                mockedUserRepository.Object,
                mockedUserFriendFactory.Object,
                mockedUnitOfWork.Object);
            var expected = new List<int>();

            // Act
            var result = friendService.GetAllUserFriendsIds(userId);

            // Assert
            CollectionAssert.AreEqual(result, expected);
        }
    }
}
