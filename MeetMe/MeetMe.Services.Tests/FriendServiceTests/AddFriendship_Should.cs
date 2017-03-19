using NUnit.Framework;
using Moq;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;

namespace MeetMe.Services.Tests.FriendServiceTests
{
    [TestFixture]
    public class AddFriendship_Should
    {
        [Test]
        public void CallUserFriendFactory_CreateUserFriendOnce()
        {
            // Arrange
            var mockedUserFriendRepository = new Mock<IEFRepository<UserFriend>>();
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var mockedUserFriendFactory = new Mock<IUserFriendFactory>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var friendService = new FriendService(
                mockedUserFriendRepository.Object,
                mockedUserRepository.Object,
                mockedUserFriendFactory.Object,
                mockedUnitOfWork.Object);
            int userId = 10;
            string friendIdentityId = "friend-xx-id";
            int friendId = 50;

            // Act
            friendService.AddFriendship(userId, friendIdentityId, friendId);

            // Assert
            mockedUserFriendFactory
                .Verify(
                    x => x.CreateUserFriend(
                        It.Is<int>(u => u == userId),
                        It.Is<string>(i => i == friendIdentityId),
                        It.Is<int>(f => f == friendId)),
                        Times.Once);
        }

        [Test]
        public void CallUserFriendRepository_AddOnce()
        {
            // Arrange
            var mockedUserFriendRepository = new Mock<IEFRepository<UserFriend>>();
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var mockedUserFriendFactory = new Mock<IUserFriendFactory>();
            var friendShip = new UserFriend();
            mockedUserFriendFactory
                .Setup(
                    x => x.CreateUserFriend(
                        It.IsAny<int>(),
                        It.IsAny<string>(),
                        It.IsAny<int>()))
                .Returns(friendShip);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var friendService = new FriendService(
                mockedUserFriendRepository.Object,
                mockedUserRepository.Object,
                mockedUserFriendFactory.Object,
                mockedUnitOfWork.Object);
            int userId = 10;
            string friendIdentityId = "friend-xx-id";
            int friendId = 50;

            // Act
            friendService.AddFriendship(userId, friendIdentityId, friendId);

            // Assert
            mockedUserFriendRepository.Verify(x => x.Add(It.Is<UserFriend>(u => u == friendShip)), Times.Once);
        }

        [Test]
        public void CallUnitOfWork_CommitOnce()
        {
            // Arrange
            var mockedUserFriendRepository = new Mock<IEFRepository<UserFriend>>();
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var mockedUserFriendFactory = new Mock<IUserFriendFactory>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var friendService = new FriendService(
                mockedUserFriendRepository.Object,
                mockedUserRepository.Object,
                mockedUserFriendFactory.Object,
                mockedUnitOfWork.Object);
            int userId = 10;
            string friendIdentityId = "friend-xx-id";
            int friendId = 50;

            // Act
            friendService.AddFriendship(userId, friendIdentityId, friendId);

            // Assert
            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}
