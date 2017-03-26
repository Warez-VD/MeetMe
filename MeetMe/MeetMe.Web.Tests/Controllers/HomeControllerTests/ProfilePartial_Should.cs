using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using MeetMe.Web.Auth.Contracts;
using MeetMe.Web.Controllers;
using MeetMe.Web.Helpers.Contracts;
using MeetMe.Web.Models.Home;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace MeetMe.Web.Tests.Controllers.HomeControllerTests
{
    [TestFixture]
    public class ProfilePartial_Should
    {
        [Test]
        public void ReturnPartialView_ProfilePartial()
        {
            // Arrange
            var mockedAccountService = new Mock<IAccountService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedStatisticService = new Mock<IStatisticService>();
            var mockedViewModelService = new Mock<IViewModelService>();
            var model = new ProfilePartialViewModel();
            mockedViewModelService.Setup(x => x.GetMappedProfilePartial(It.IsAny<CustomUser>())).Returns(model);

            var mockedSignInManager = new Mock<ISignInManager>();
            var mockedUserManager = new Mock<IUserManager>();
            var mockedIdentityHelper = new Mock<IIdentityHelper>();
            
            var homeController = new HomeController(
                mockedAccountService.Object,
                mockedUserService.Object,
                mockedStatisticService.Object,
                mockedViewModelService.Object,
                mockedSignInManager.Object,
                mockedUserManager.Object,
                mockedIdentityHelper.Object);

            // Act & Assert
            homeController
                .WithCallTo(x => x.ProfilePartial())
                .ShouldRenderPartialView("_ProfilePartial")
                .WithModel<ProfilePartialViewModel>(m => 
                {
                    Assert.AreEqual(model, m);
                });
        }
    }
}
