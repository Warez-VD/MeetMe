using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using MeetMe.Web.Controllers;
using MeetMe.Web.Models.Profile;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace MeetMe.Web.Tests.Controllers.ProfileControllerTests
{
    [TestFixture]
    public class Edit_Should
    {
        [Test]
        public void ReturnPartialView_WithSameModel_WhenNoErrors()
        {
            // Arrange
            var mockedAccountService = new Mock<IAccountService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedFriendService = new Mock<IFriendService>();
            var mockedViewModelService = new Mock<IViewModelService>();
            var updatedModel = new ProfilePersonalnfo();
            mockedViewModelService.Setup(x => x.GetMappedProfilePersonalInfo(It.IsAny<CustomUser>())).Returns(updatedModel);

            var profileController = new ProfileController(
                mockedAccountService.Object,
                mockedUserService.Object,
                mockedFriendService.Object,
                mockedViewModelService.Object);
            var model = new ProfilePersonalnfo();

            // Act & Assert
            profileController
                .WithCallTo(x => x.Edit(model))
                .ShouldRenderPartialView("_ProfilePersonalInfoPartial")
                .WithModel(updatedModel);
        }
    }
}
