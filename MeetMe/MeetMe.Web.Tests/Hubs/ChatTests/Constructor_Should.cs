using System;
using MeetMe.Services.Contracts;
using MeetMe.Web.Hubs;
using Moq;
using NUnit.Framework;

namespace MeetMe.Web.Tests.Hubs.ChatTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhen_ConversationServiceIsNull()
        {
            // Arrange
            var mockedUserService = new Mock<IUserService>();
            var mockedViewModelService = new Mock<IViewModelService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new Chat(
                null,
                mockedUserService.Object,
                mockedViewModelService.Object));

            // Assert
            Assert.That(ex.Message.Contains("ConversationService"));
        }

        [Test]
        public void ThrowsWhen_UserServiceIsNull()
        {
            // Arrange
            var mockedConversationService = new Mock<IConversationService>();
            var mockedViewModelService = new Mock<IViewModelService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new Chat(
                mockedConversationService.Object,
                null,
                mockedViewModelService.Object));

            // Assert
            Assert.That(ex.Message.Contains("UserService"));
        }

        [Test]
        public void ThrowsWhen_ViewModelServiceIsNull()
        {
            // Arrange
            var mockedConversationService = new Mock<IConversationService>();
            var mockedUserService = new Mock<IUserService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new Chat(
                mockedConversationService.Object,
                mockedUserService.Object,
                null));

            // Assert
            Assert.That(ex.Message.Contains("ViewModelService"));
        }

        [Test]
        public void ReturnInstanceOfChat_Correct()
        {
            // Arrange
            var mockedConversationService = new Mock<IConversationService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedViewModelService = new Mock<IViewModelService>();

            // Act
            var chat = new Chat(
                mockedConversationService.Object,
                mockedUserService.Object,
                mockedViewModelService.Object);
            
            // Assert
            Assert.IsNotNull(chat);
            Assert.IsInstanceOf<Chat>(chat);
        }
    }
}
