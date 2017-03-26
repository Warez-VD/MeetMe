using System;
using MeetMe.Services.Contracts;
using MeetMe.Web.Controllers;
using Moq;
using NUnit.Framework;

namespace MeetMe.Web.Tests.Controllers.MessageControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhen_UserServiceIsNull()
        {
            // Arrange
            var mockedViewModelService = new Mock<IViewModelService>();
            var mockedFriendService = new Mock<IFriendService>();
            var mockedConversationService = new Mock<IConversationService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new MessageController(
                null,
                mockedViewModelService.Object,
                mockedFriendService.Object,
                mockedConversationService.Object));

            // Assert
            Assert.That(ex.Message.Contains("UserService"));
        }

        [Test]
        public void ThrowsWhen_ViewModelServiceIsNull()
        {
            // Arrange
            var mockedUserService = new Mock<IUserService>();
            var mockedFriendService = new Mock<IFriendService>();
            var mockedConversationService = new Mock<IConversationService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new MessageController(
                mockedUserService.Object,
                null,
                mockedFriendService.Object,
                mockedConversationService.Object));

            // Assert
            Assert.That(ex.Message.Contains("ViewModelService"));
        }

        [Test]
        public void ThrowsWhen_FriendServiceIsNull()
        {
            // Arrange
            var mockedUserService = new Mock<IUserService>();
            var mockedViewModelService = new Mock<IViewModelService>();
            var mockedConversationService = new Mock<IConversationService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new MessageController(
                mockedUserService.Object,
                mockedViewModelService.Object,
                null,
                mockedConversationService.Object));

            // Assert
            Assert.That(ex.Message.Contains("FriendService"));
        }

        [Test]
        public void ThrowsWhen_ConversationServiceIsNull()
        {
            // Arrange
            var mockedUserService = new Mock<IUserService>();
            var mockedViewModelService = new Mock<IViewModelService>();
            var mockedFriendService = new Mock<IFriendService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new MessageController(
                mockedUserService.Object,
                mockedViewModelService.Object,
                mockedFriendService.Object,
                null));

            // Assert
            Assert.That(ex.Message.Contains("ConversationService"));
        }

        [Test]
        public void ReturnInstanceOfMessageController_Correct()
        {
            // Arrange
            var mockedUserService = new Mock<IUserService>();
            var mockedViewModelService = new Mock<IViewModelService>();
            var mockedFriendService = new Mock<IFriendService>();
            var mockedConversationService = new Mock<IConversationService>();

            // Act
            var messageController = new MessageController(
                mockedUserService.Object,
                mockedViewModelService.Object,
                mockedFriendService.Object,
                mockedConversationService.Object);

            // Assert
            Assert.IsNotNull(messageController);
            Assert.IsInstanceOf<MessageController>(messageController);
        }
    }
}
