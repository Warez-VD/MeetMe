using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace MeetMe.Services.Tests.ConversationServiceTests
{
    [TestFixture]
    public class CreateConversation_Should
    {
        [Test]
        public void CallConversationFactory_CreateConversationOnce()
        {
            // Arrange
            var mockedConversationRepository = new Mock<IEFRepository<Conversation>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedConversationFactory = new Mock<IConversationFactory>();
            var mockedMessageService = new Mock<IMessageService>();

            var conversationService = new ConversationService(
                mockedConversationRepository.Object,
                mockedUnitOfWork.Object,
                mockedConversationFactory.Object,
                mockedMessageService.Object);
            string userId = "user-id-xx";
            string friendId = "friend-id-xx";

            // Act
            conversationService.CreateConversation(userId, friendId);

            // Assert
            mockedConversationFactory.Verify(x => x.CreateConversation(userId, friendId), Times.Once);
        }

        [Test]
        public void CallConversationRepository_AddOnce_WithCreatedConversation()
        {
            // Arrange
            var mockedConversationRepository = new Mock<IEFRepository<Conversation>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedConversationFactory = new Mock<IConversationFactory>();
            var conversation = new Conversation();
            mockedConversationFactory.Setup(x => x.CreateConversation(It.IsAny<string>(), It.IsAny<string>())).Returns(conversation);
            var mockedMessageService = new Mock<IMessageService>();

            var conversationService = new ConversationService(
                mockedConversationRepository.Object,
                mockedUnitOfWork.Object,
                mockedConversationFactory.Object,
                mockedMessageService.Object);
            string userId = "user-id-xx";
            string friendId = "friend-id-xx";

            // Act
            conversationService.CreateConversation(userId, friendId);

            // Assert
            mockedConversationRepository.Verify(x => x.Add(conversation), Times.Once);
        }

        [Test]
        public void CallUnitOfWork_CommitOnce()
        {
            // Arrange
            var mockedConversationRepository = new Mock<IEFRepository<Conversation>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedConversationFactory = new Mock<IConversationFactory>();
            var mockedMessageService = new Mock<IMessageService>();

            var conversationService = new ConversationService(
                mockedConversationRepository.Object,
                mockedUnitOfWork.Object,
                mockedConversationFactory.Object,
                mockedMessageService.Object);
            string userId = "user-id-xx";
            string friendId = "friend-id-xx";

            // Act
            conversationService.CreateConversation(userId, friendId);

            // Assert
            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}
