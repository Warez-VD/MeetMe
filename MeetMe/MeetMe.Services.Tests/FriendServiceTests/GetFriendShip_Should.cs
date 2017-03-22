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
    public class GetFriendShip_Should
    {
        [Test]
        public void ReturnFriendship_WhenFound()
        {
            // Arrange
            int currentUserId = 15;
            int friendId = 10;

            var mockedUserFriendRepository = new Mock<IEFRepository<UserFriend>>();
            var friendships = new List<UserFriend>()
            {
                new UserFriend() { UserId = 1, FriendId = 3 },
                new UserFriend() { UserId = currentUserId, FriendId = friendId },
                new UserFriend() { UserId = 7, FriendId = 12 }
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
            var result = friendService.GetFriendShip(currentUserId, friendId);

            // Assert
            Assert.AreEqual(result.UserId, currentUserId);
            Assert.AreEqual(result.FriendId, friendId);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<UserFriend>(result);
        }

        [Test]
        public void ReturnNull_WhenNotFound()
        {
            // Arrange
            int currentUserId = 15;
            int friendId = 10;

            var mockedUserFriendRepository = new Mock<IEFRepository<UserFriend>>();
            var friendships = new List<UserFriend>()
            {
                new UserFriend() { UserId = 1, FriendId = 3 },
                new UserFriend() { UserId = 2, FriendId = 4 },
                new UserFriend() { UserId = 7, FriendId = 12 }
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
            var result = friendService.GetFriendShip(currentUserId, friendId);

            // Assert
            Assert.IsNull(result);
        }
    }
}
