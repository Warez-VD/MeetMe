using System;
using MeetMe.Services.Contracts;
using MeetMe.Web.Auth.Contracts;
using MeetMe.Web.Controllers;
using Moq;
using NUnit.Framework;

namespace MeetMe.Web.Tests.Controllers.AdminControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhen_UserServiceIsNull()
        {
            // Arrange
            var mockedViewModelService = new Mock<IViewModelService>();
            var mockedUserManager = new Mock<IUserManager>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new AdminController(
                null,
                mockedViewModelService.Object,
                mockedUserManager.Object));

            // Assert
            Assert.That(ex.Message.Contains("UserService"));
        }

        [Test]
        public void ThrowsWhen_ViewModelServiceIsNull()
        {
            // Arrange
            var mockedUserService = new Mock<IUserService>();
            var mockedUserManager = new Mock<IUserManager>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new AdminController(
                mockedUserService.Object,
                null,
                mockedUserManager.Object));

            // Assert
            Assert.That(ex.Message.Contains("ViewModelService"));
        }

        [Test]
        public void ThrowsWhen_UserManagerIsNull()
        {
            // Arrange
            var mockedUserService = new Mock<IUserService>();
            var mockedViewModelService = new Mock<IViewModelService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new AdminController(
                mockedUserService.Object,
                mockedViewModelService.Object,
                null));

            // Assert
            Assert.That(ex.Message.Contains("UserManager"));
        }

        [Test]
        public void ReturnInstanceOfAdminController_Correct()
        {
            // Arrange
            var mockedUserService = new Mock<IUserService>();
            var mockedViewModelService = new Mock<IViewModelService>();
            var mockedUserManager = new Mock<IUserManager>();

            // Act
            var adminController = new AdminController(
                mockedUserService.Object,
                mockedViewModelService.Object,
                mockedUserManager.Object);

            // Assert
            Assert.IsNotNull(adminController);
            Assert.IsInstanceOf<AdminController>(adminController);
        }
    }
}
