using System;
using NUnit.Framework;
using Moq;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;

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

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new UserService(
                null,
                mockedFriendService.Object,
                mockedUnitOfWork.Object));

            // Assert
            Assert.That(ex.Message.Contains("UserRepository"));
        }

        [Test]
        public void ThrowsWhen_FriendServiceIsNull()
        {
            // Arrange
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new UserService(
                mockedUserRepository.Object,
                null,
                mockedUnitOfWork.Object));

            // Assert
            Assert.That(ex.Message.Contains("FriendService"));
        }

        [Test]
        public void ThrowsWhen_UnitOfWorkIsNull()
        {
            // Arrange
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var mockedFriendService = new Mock<IFriendService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new UserService(
                mockedUserRepository.Object,
                mockedFriendService.Object,
                null));

            // Assert
            Assert.That(ex.Message.Contains("UnitOfWork"));
        }

        [Test]
        public void ReturnInstanceOfStatisticService_Correct()
        {
            // Arrange
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var mockedFriendService = new Mock<IFriendService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            // Act
            var userService = new UserService(
                mockedUserRepository.Object,
                mockedFriendService.Object,
                mockedUnitOfWork.Object);

            // Assert
            Assert.IsNotNull(userService);
            Assert.IsInstanceOf<UserService>(userService);
        }
    }
}
