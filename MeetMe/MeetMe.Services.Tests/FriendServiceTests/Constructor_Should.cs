using System;
using NUnit.Framework;
using Moq;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;

namespace MeetMe.Services.Tests.FriendServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhen_UserFriendRepositoryIsNull()
        {
            // Arrange
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var mockedUserFriendFactory = new Mock<IUserFriendFactory>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new FriendService(
                null,
                mockedUserRepository.Object,
                mockedUserFriendFactory.Object,
                mockedUnitOfWork.Object));

            // Assert
            Assert.That(ex.Message.Contains("UserFriendRepository"));
        }

        [Test]
        public void ThrowsWhen_UserRepositoryIsNull()
        {
            // Arrange
            var mockedUserFriendRepository = new Mock<IEFRepository<UserFriend>>();
            var mockedUserFriendFactory = new Mock<IUserFriendFactory>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new FriendService(
                mockedUserFriendRepository.Object,
                null,
                mockedUserFriendFactory.Object,
                mockedUnitOfWork.Object));

            // Assert
            Assert.That(ex.Message.Contains("UserRepository"));
        }

        [Test]
        public void ThrowsWhen_UserFriendFactoryIsNull()
        {
            // Arrange
            var mockedUserFriendRepository = new Mock<IEFRepository<UserFriend>>();
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new FriendService(
                mockedUserFriendRepository.Object,
                mockedUserRepository.Object,
                null,
                mockedUnitOfWork.Object));

            // Assert
            Assert.That(ex.Message.Contains("UserFriendFactory"));
        }

        [Test]
        public void ThrowsWhen_UnitOfWorkIsNull()
        {
            // Arrange
            var mockedUserFriendRepository = new Mock<IEFRepository<UserFriend>>();
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var mockedUserFriendFactory = new Mock<IUserFriendFactory>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new FriendService(
                mockedUserFriendRepository.Object,
                mockedUserRepository.Object,
                mockedUserFriendFactory.Object,
                null));

            // Assert
            Assert.That(ex.Message.Contains("UnitOfWork"));
        }

        [Test]
        public void ReturnInstanceOfAccountService_Correct()
        {
            // Arrange
            var mockedUserFriendRepository = new Mock<IEFRepository<UserFriend>>();
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var mockedUserFriendFactory = new Mock<IUserFriendFactory>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            // Act
            var friendService = new FriendService(
                mockedUserFriendRepository.Object,
                mockedUserRepository.Object,
                mockedUserFriendFactory.Object,
                mockedUnitOfWork.Object);

            // Assert
            Assert.IsNotNull(friendService);
            Assert.IsInstanceOf<FriendService>(friendService);
        }
    }
}
