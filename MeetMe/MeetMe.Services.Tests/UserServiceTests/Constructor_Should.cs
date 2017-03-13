using System;
using NUnit.Framework;
using Moq;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;

namespace MeetMe.Services.Tests.UserServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhen_UserRepositoryIsNull()
        {
            // Arrange & Act
            var ex = Assert.Throws<ArgumentNullException>(() => new UserService(null));

            // Assert
            Assert.That(ex.Message.Contains("UserRepository"));
        }

        [Test]
        public void ReturnInstanceOfStatisticService_Correct()
        {
            // Arrange
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();

            // Act
            var userService = new UserService(mockedUserRepository.Object);

            // Assert
            Assert.IsNotNull(userService);
            Assert.IsInstanceOf<UserService>(userService);
        }
    }
}
