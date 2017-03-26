using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace MeetMe.Services.Tests.ConversationServiceTests
{
    [TestFixture]
    public class AddMessageToConversation_Should
    {
        [Test]
        public void CallMessageService_CreateMessageOnce()
        {
            // Arrange
            var mockedConversationRepository = new Mock<IEFRepository<Conversation>>();
            var conversation = new Conversation();
            mockedConversationRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(conversation);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedConversationFactory = new Mock<IConversationFactory>();
            var mockedMessageService = new Mock<IMessageService>();

            var conversationService = new ConversationService(
                mockedConversationRepository.Object,
                mockedUnitOfWork.Object,
                mockedConversationFactory.Object,
                mockedMessageService.Object);
            int id = 5;
            var user = new CustomUser();
            string content = "some content";

            // Act
            conversationService.AddMessageToConversation(id, user, content);

            // Assert
            mockedMessageService.Verify(x => x.CreateMessage(user, content), Times.Once);
        }

        [Test]
        public void CallConversationRepository_UpdateOnce_WithAddedMessageToConversation()
        {
            // Arrange
            var mockedConversationRepository = new Mock<IEFRepository<Conversation>>();
            var conversation = new Conversation();
            mockedConversationRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(conversation);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedConversationFactory = new Mock<IConversationFactory>();
            var mockedMessageService = new Mock<IMessageService>();
            var message = new Message();
            mockedMessageService.Setup(x => x.CreateMessage(It.IsAny<CustomUser>(), It.IsAny<string>())).Returns(message);

            var conversationService = new ConversationService(
                mockedConversationRepository.Object,
                mockedUnitOfWork.Object,
                mockedConversationFactory.Object,
                mockedMessageService.Object);
            int id = 5;
            var user = new CustomUser();
            string content = "some content";

            // Act
            conversationService.AddMessageToConversation(id, user, content);

            // Assert
            mockedConversationRepository.Verify(x => x.Update(It.Is<Conversation>(c => c == conversation && conversation.Messages.Contains(message))), Times.Once);
        }

        [Test]
        public void CallUnitOfWork_CommitOnce()
        {
            // Arrange
            var mockedConversationRepository = new Mock<IEFRepository<Conversation>>();
            var conversation = new Conversation();
            mockedConversationRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(conversation);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedConversationFactory = new Mock<IConversationFactory>();
            var mockedMessageService = new Mock<IMessageService>();

            var conversationService = new ConversationService(
                mockedConversationRepository.Object,
                mockedUnitOfWork.Object,
                mockedConversationFactory.Object,
                mockedMessageService.Object);
            int id = 5;
            var user = new CustomUser();
            string content = "some content";

            // Act
            conversationService.AddMessageToConversation(id, user, content);

            // Assert
            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void ReturnAddedMessageToConversation()
        {
            // Arrange
            var mockedConversationRepository = new Mock<IEFRepository<Conversation>>();
            var conversation = new Conversation();
            mockedConversationRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(conversation);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedConversationFactory = new Mock<IConversationFactory>();
            var mockedMessageService = new Mock<IMessageService>();
            var message = new Message();
            mockedMessageService.Setup(x => x.CreateMessage(It.IsAny<CustomUser>(), It.IsAny<string>())).Returns(message);

            var conversationService = new ConversationService(
                mockedConversationRepository.Object,
                mockedUnitOfWork.Object,
                mockedConversationFactory.Object,
                mockedMessageService.Object);
            int id = 5;
            var user = new CustomUser();
            string content = "some content";

            // Act
            var result = conversationService.AddMessageToConversation(id, user, content);

            // Assert
            Assert.AreEqual(message, result);
        }
    }
}
