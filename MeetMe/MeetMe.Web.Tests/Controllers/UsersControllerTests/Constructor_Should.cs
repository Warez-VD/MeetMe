using System;
using MeetMe.Services.Contracts;
using MeetMe.Web.Controllers;
using Moq;
using NUnit.Framework;

namespace MeetMe.Web.Tests.Controllers.UsersControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhen_UserServiceIsNull()
        {
            // Arrange & Act
            var ex = Assert.Throws<ArgumentNullException>(() => new UsersController(null));

            // Assert
            Assert.That(ex.Message.Contains("UserService"));
        }

        [Test]
        public void ReturnInstanceOfUsersController_Correct()
        {
            // Arrange
            var mockedUserService = new Mock<IUserService>();

            // Act
            var usersController = new UsersController(mockedUserService.Object);

            // Assert
            Assert.IsNotNull(usersController);
            Assert.IsInstanceOf<UsersController>(usersController);
        }
    }
}
