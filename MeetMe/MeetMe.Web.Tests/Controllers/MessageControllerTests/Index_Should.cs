using System.Collections.Generic;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using MeetMe.Web.Controllers;
using MeetMe.Web.Models.Messages;
using MeetMe.Web.Models.Profile;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace MeetMe.Web.Tests.Controllers.MessageControllerTests
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public void RedirectToHome_WhenIdIsNull()
        {
            // Arrange
            var mockedUserService = new Mock<IUserService>();
            var mockedViewModelService = new Mock<IViewModelService>();
            var mockedFriendService = new Mock<IFriendService>();
            var mockedConversationService = new Mock<IConversationService>();
            
            var messageController = new MessageController(
                mockedUserService.Object,
                mockedViewModelService.Object,
                mockedFriendService.Object,
                mockedConversationService.Object);

            // Act & Assert
            messageController
                .WithCallTo(x => x.Index(null))
                .ShouldRedirectTo<HomeController>(typeof(HomeController).GetMethod("Index"));
        }

        [Test]
        public void ReturnDefaultIndex()
        {
            // Arrange
            var mockedUserService = new Mock<IUserService>();
            var user = new CustomUser();
            mockedUserService.Setup(x => x.GetByIndentityId(It.IsAny<string>())).Returns(user);
            
            var mockedViewModelService = new Mock<IViewModelService>();
            mockedViewModelService.Setup(x => x.GetMappedUserFriends(It.IsAny<IEnumerable<CustomUser>>())).Returns(new List<ProfileFriendViewModel>());
            mockedViewModelService.Setup(x => x.GetMappedConversations(It.IsAny<IEnumerable<Conversation>>())).Returns(new List<ConversationViewModel>());

            var mockedFriendService = new Mock<IFriendService>();
            var mockedConversationService = new Mock<IConversationService>();

            var messageController = new MessageController(
                mockedUserService.Object,
                mockedViewModelService.Object,
                mockedFriendService.Object,
                mockedConversationService.Object);
            string id = "some-id";

            // Act & Assert
            messageController
                .WithCallTo(x => x.Index(id))
                .ShouldRenderDefaultView()
                .WithModel<MessageIndexViewModel>();
        }
    }
}
