using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using MeetMe.Web.Controllers;
using MeetMe.Web.Models.Messages;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace MeetMe.Web.Tests.Controllers.MessageControllerTests
{
    [TestFixture]
    public class Conversation_Should
    {
        [Test]
        public void ReturnPartialView_ConversationPartial()
        {
            // Arrange
            var mockedUserService = new Mock<IUserService>();
            var mockedViewModelService = new Mock<IViewModelService>();
            var model = new ConversationViewModel();
            mockedViewModelService.Setup(x => x.GetMappedConversation(It.IsAny<Conversation>())).Returns(model);

            var mockedFriendService = new Mock<IFriendService>();
            var mockedConversationService = new Mock<IConversationService>();

            var messageController = new MessageController(
                mockedUserService.Object,
                mockedViewModelService.Object,
                mockedFriendService.Object,
                mockedConversationService.Object);
            int id = 4;

            // Act & Assert
            messageController
                .WithCallTo(x => x.Conversation(id))
                .ShouldRenderPartialView("_ConversationPartial")
                .WithModel<ConversationViewModel>(m => 
                {
                    Assert.AreEqual(model, m);
                });
        }
    }
}
