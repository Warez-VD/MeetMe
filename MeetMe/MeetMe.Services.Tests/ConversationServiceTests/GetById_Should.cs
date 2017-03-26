using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace MeetMe.Services.Tests.ConversationServiceTests
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void ReturnConversation_WhenFound()
        {
            // Arrange
            int id = 4;

            var mockedConversationRepository = new Mock<IEFRepository<Conversation>>();
            var conversation = new Conversation();
            mockedConversationRepository.Setup(x => x.GetById(id)).Returns(conversation);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedConversationFactory = new Mock<IConversationFactory>();
            var mockedMessageService = new Mock<IMessageService>();

            var conversationService = new ConversationService(
                mockedConversationRepository.Object,
                mockedUnitOfWork.Object,
                mockedConversationFactory.Object,
                mockedMessageService.Object);

            // Act
            var result = conversationService.GetById(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Conversation>(result);
            Assert.AreEqual(conversation, result);
        }

        [Test]
        public void ReturnNull_WhenNotFound()
        {
            // Arrange
            int id = 4;

            var mockedConversationRepository = new Mock<IEFRepository<Conversation>>();
            var conversation = new Conversation();
            mockedConversationRepository.Setup(x => x.GetById(id)).Returns(conversation);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedConversationFactory = new Mock<IConversationFactory>();
            var mockedMessageService = new Mock<IMessageService>();

            var conversationService = new ConversationService(
                mockedConversationRepository.Object,
                mockedUnitOfWork.Object,
                mockedConversationFactory.Object,
                mockedMessageService.Object);

            // Act
            var result = conversationService.GetById(10);

            // Assert
            Assert.IsNull(result);
        }
    }
}
