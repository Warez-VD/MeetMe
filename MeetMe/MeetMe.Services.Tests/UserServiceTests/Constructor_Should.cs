using System;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace MeetMe.Services.Tests.UserServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhen_UserRepositoryIsNull()
        {
            // Arrange
            var mockedFriendService = new Mock<IFriendService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedConversationService = new Mock<IConversationService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new UserService(
                null,
                mockedFriendService.Object,
                mockedUnitOfWork.Object,
                mockedConversationService.Object));

            // Assert
            Assert.That(ex.Message.Contains("UserRepository"));
        }

        [Test]
        public void ThrowsWhen_FriendServiceIsNull()
        {
            // Arrange
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedConversationService = new Mock<IConversationService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new UserService(
                mockedUserRepository.Object,
                null,
                mockedUnitOfWork.Object,
                mockedConversationService.Object));

            // Assert
            Assert.That(ex.Message.Contains("FriendService"));
        }

        [Test]
        public void ThrowsWhen_UnitOfWorkIsNull()
        {
            // Arrange
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var mockedFriendService = new Mock<IFriendService>();
            var mockedConversationService = new Mock<IConversationService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new UserService(
                mockedUserRepository.Object,
                mockedFriendService.Object,
                null,
                mockedConversationService.Object));

            // Assert
            Assert.That(ex.Message.Contains("UnitOfWork"));
        }

        [Test]
        public void ThrowsWhen_ConversationServiceIsNull()
        {
            // Arrange
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var mockedFriendService = new Mock<IFriendService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new UserService(
                mockedUserRepository.Object,
                mockedFriendService.Object,
                mockedUnitOfWork.Object,
                null));

            // Assert
            Assert.That(ex.Message.Contains("ConversationService"));
        }

        [Test]
        public void ReturnInstanceOfStatisticService_Correct()
        {
            // Arrange
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var mockedFriendService = new Mock<IFriendService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedConversationService = new Mock<IConversationService>();

            // Act
            var userService = new UserService(
                mockedUserRepository.Object,
                mockedFriendService.Object,
                mockedUnitOfWork.Object,
                mockedConversationService.Object);

            // Assert
            Assert.IsNotNull(userService);
            Assert.IsInstanceOf<UserService>(userService);
        }
    }
}
