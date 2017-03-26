using System;
using MeetMe.Services.Contracts;
using MeetMe.Web.Controllers;
using Moq;
using NUnit.Framework;

namespace MeetMe.Web.Tests.Controllers.ProfileControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhen_AccountServiceIsNull()
        {
            // Arrange
            var mockedUserService = new Mock<IUserService>();
            var mockedFriendService = new Mock<IFriendService>();
            var mockedViewModelService = new Mock<IViewModelService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new ProfileController(
                null,
                mockedUserService.Object,
                mockedFriendService.Object,
                mockedViewModelService.Object));

            // Assert
            Assert.That(ex.Message.Contains("AccountService"));
        }

        [Test]
        public void ThrowsWhen_UserServiceIsNull()
        {
            // Arrange
            var mockedAccountService = new Mock<IAccountService>();
            var mockedFriendService = new Mock<IFriendService>();
            var mockedViewModelService = new Mock<IViewModelService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new ProfileController(
                mockedAccountService.Object,
                null,
                mockedFriendService.Object,
                mockedViewModelService.Object));

            // Assert
            Assert.That(ex.Message.Contains("UserService"));
        }

        [Test]
        public void ThrowsWhen_FriendServiceIsNull()
        {
            // Arrange
            var mockedAccountService = new Mock<IAccountService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedViewModelService = new Mock<IViewModelService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new ProfileController(
                mockedAccountService.Object,
                mockedUserService.Object,
                null,
                mockedViewModelService.Object));

            // Assert
            Assert.That(ex.Message.Contains("FriendService"));
        }

        [Test]
        public void ThrowsWhen_ViewModelServiceIsNull()
        {
            // Arrange
            var mockedAccountService = new Mock<IAccountService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedFriendService = new Mock<IFriendService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new ProfileController(
                mockedAccountService.Object,
                mockedUserService.Object,
                mockedFriendService.Object,
                null));

            // Assert
            Assert.That(ex.Message.Contains("ViewModelService"));
        }

        [Test]
        public void ReturnInstanceOfProfileController_Correct()
        {
            // Arrange
            var mockedAccountService = new Mock<IAccountService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedFriendService = new Mock<IFriendService>();
            var mockedViewModelService = new Mock<IViewModelService>();

            // Act
            var profileController = new ProfileController(
                mockedAccountService.Object,
                mockedUserService.Object,
                mockedFriendService.Object,
                mockedViewModelService.Object);

            // Assert
            Assert.IsNotNull(profileController);
            Assert.IsInstanceOf<ProfileController>(profileController);
        }
    }
}
