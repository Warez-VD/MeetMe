using System;
using MeetMe.Services.Contracts;
using MeetMe.Web.Auth.Contracts;
using MeetMe.Web.Controllers;
using MeetMe.Web.Helpers.Contracts;
using Moq;
using NUnit.Framework;

namespace MeetMe.Web.Tests.Controllers.HomeControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhen_AccountServiceIsNull()
        {
            // Arrange
            var mockedUserService = new Mock<IUserService>();
            var mockedStatisticService = new Mock<IStatisticService>();
            var mockedViewModelService = new Mock<IViewModelService>();
            var mockedSignInManager = new Mock<ISignInManager>();
            var mockedUserManager = new Mock<IUserManager>();
            var mockedIdentityHelper = new Mock<IIdentityHelper>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new HomeController(
                null,
                mockedUserService.Object,
                mockedStatisticService.Object,
                mockedViewModelService.Object,
                mockedSignInManager.Object,
                mockedUserManager.Object,
                mockedIdentityHelper.Object));

            // Assert
            Assert.That(ex.Message.Contains("AccountService"));
        }

        [Test]
        public void ThrowsWhen_UserServiceIsNull()
        {
            // Arrange
            var mockedAccountService = new Mock<IAccountService>();
            var mockedStatisticService = new Mock<IStatisticService>();
            var mockedViewModelService = new Mock<IViewModelService>();
            var mockedSignInManager = new Mock<ISignInManager>();
            var mockedUserManager = new Mock<IUserManager>();
            var mockedIdentityHelper = new Mock<IIdentityHelper>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new HomeController(
                mockedAccountService.Object,
                null,
                mockedStatisticService.Object,
                mockedViewModelService.Object,
                mockedSignInManager.Object,
                mockedUserManager.Object,
                mockedIdentityHelper.Object));

            // Assert
            Assert.That(ex.Message.Contains("UserService"));
        }

        [Test]
        public void ThrowsWhen_StatisticServiceIsNull()
        {
            // Arrange
            var mockedAccountService = new Mock<IAccountService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedViewModelService = new Mock<IViewModelService>();
            var mockedSignInManager = new Mock<ISignInManager>();
            var mockedUserManager = new Mock<IUserManager>();
            var mockedIdentityHelper = new Mock<IIdentityHelper>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new HomeController(
                mockedAccountService.Object,
                mockedUserService.Object,
                null,
                mockedViewModelService.Object,
                mockedSignInManager.Object,
                mockedUserManager.Object,
                mockedIdentityHelper.Object));

            // Assert
            Assert.That(ex.Message.Contains("StatisticService"));
        }

        [Test]
        public void ThrowsWhen_ViewModelServiceIsNull()
        {
            // Arrange
            var mockedAccountService = new Mock<IAccountService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedStatisticService = new Mock<IStatisticService>();
            var mockedSignInManager = new Mock<ISignInManager>();
            var mockedUserManager = new Mock<IUserManager>();
            var mockedIdentityHelper = new Mock<IIdentityHelper>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new HomeController(
                mockedAccountService.Object,
                mockedUserService.Object,
                mockedStatisticService.Object,
                null,
                mockedSignInManager.Object,
                mockedUserManager.Object,
                mockedIdentityHelper.Object));

            // Assert
            Assert.That(ex.Message.Contains("ViewModelService"));
        }

        [Test]
        public void ThrowsWhen_SignInManagerIsNull()
        {
            // Arrange
            var mockedAccountService = new Mock<IAccountService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedStatisticService = new Mock<IStatisticService>();
            var mockedViewModelService = new Mock<IViewModelService>();
            var mockedUserManager = new Mock<IUserManager>();
            var mockedIdentityHelper = new Mock<IIdentityHelper>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new HomeController(
                mockedAccountService.Object,
                mockedUserService.Object,
                mockedStatisticService.Object,
                mockedViewModelService.Object,
                null,
                mockedUserManager.Object,
                mockedIdentityHelper.Object));

            // Assert
            Assert.That(ex.Message.Contains("SignInManager"));
        }

        [Test]
        public void ThrowsWhen_UserManagerIsNull()
        {
            // Arrange
            var mockedAccountService = new Mock<IAccountService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedStatisticService = new Mock<IStatisticService>();
            var mockedViewModelService = new Mock<IViewModelService>();
            var mockedSignInManager = new Mock<ISignInManager>();
            var mockedIdentityHelper = new Mock<IIdentityHelper>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new HomeController(
                mockedAccountService.Object,
                mockedUserService.Object,
                mockedStatisticService.Object,
                mockedViewModelService.Object,
                mockedSignInManager.Object,
                null,
                mockedIdentityHelper.Object));

            // Assert
            Assert.That(ex.Message.Contains("UserManager"));
        }

        [Test]
        public void ThrowsWhen_IdentityHelperIsNull()
        {
            // Arrange
            var mockedAccountService = new Mock<IAccountService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedStatisticService = new Mock<IStatisticService>();
            var mockedViewModelService = new Mock<IViewModelService>();
            var mockedSignInManager = new Mock<ISignInManager>();
            var mockedUserManager = new Mock<IUserManager>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new HomeController(
                mockedAccountService.Object,
                mockedUserService.Object,
                mockedStatisticService.Object,
                mockedViewModelService.Object,
                mockedSignInManager.Object,
                mockedUserManager.Object,
                null));

            // Assert
            Assert.That(ex.Message.Contains("IdentityHelper"));
        }

        [Test]
        public void ReturnInstanceOfHomeController_Correct()
        {
            // Arrange
            var mockedAccountService = new Mock<IAccountService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedStatisticService = new Mock<IStatisticService>();
            var mockedViewModelService = new Mock<IViewModelService>();
            var mockedSignInManager = new Mock<ISignInManager>();
            var mockedUserManager = new Mock<IUserManager>();
            var mockedIdentityHelper = new Mock<IIdentityHelper>();

            // Act
            var homeController = new HomeController(
                mockedAccountService.Object,
                mockedUserService.Object,
                mockedStatisticService.Object,
                mockedViewModelService.Object,
                mockedSignInManager.Object,
                mockedUserManager.Object,
                mockedIdentityHelper.Object);

            // Assert
            Assert.IsNotNull(homeController);
            Assert.IsInstanceOf<HomeController>(homeController);
        }
    }
}
