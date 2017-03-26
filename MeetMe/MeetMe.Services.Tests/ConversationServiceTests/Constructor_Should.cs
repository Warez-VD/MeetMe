using System;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace MeetMe.Services.Tests.ConversationServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhen_ConversationRepositoryIsNull()
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedConversationFactory = new Mock<IConversationFactory>();
            var mockedMessageService = new Mock<IMessageService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new ConversationService(
                null,
                mockedUnitOfWork.Object,
                mockedConversationFactory.Object,
                mockedMessageService.Object));

            // Assert
            Assert.That(ex.Message.Contains("ConversationRepository"));
        }

        [Test]
        public void ThrowsWhen_UnitOfWorkIsNull()
        {
            // Arrange
            var mockedConversationRepository = new Mock<IEFRepository<Conversation>>();
            var mockedConversationFactory = new Mock<IConversationFactory>();
            var mockedMessageService = new Mock<IMessageService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new ConversationService(
                mockedConversationRepository.Object,
                null,
                mockedConversationFactory.Object,
                mockedMessageService.Object));

            // Assert
            Assert.That(ex.Message.Contains("UnitOfWork"));
        }

        [Test]
        public void ThrowsWhen_ConversationFactoryIsNull()
        {
            // Arrange
            var mockedConversationRepository = new Mock<IEFRepository<Conversation>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMessageService = new Mock<IMessageService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new ConversationService(
                mockedConversationRepository.Object,
                mockedUnitOfWork.Object,
                null,
                mockedMessageService.Object));

            // Assert
            Assert.That(ex.Message.Contains("ConversationFactory"));
        }

        [Test]
        public void ThrowsWhen_MessageServiceIsNull()
        {
            // Arrange
            var mockedConversationRepository = new Mock<IEFRepository<Conversation>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedConversationFactory = new Mock<IConversationFactory>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new ConversationService(
                mockedConversationRepository.Object,
                mockedUnitOfWork.Object,
                mockedConversationFactory.Object,
                null));

            // Assert
            Assert.That(ex.Message.Contains("MessageService"));
        }

        [Test]
        public void ReturnInstanceOfConversationService_Correct()
        {
            // Arrange
            var mockedConversationRepository = new Mock<IEFRepository<Conversation>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedConversationFactory = new Mock<IConversationFactory>();
            var mockedMessageService = new Mock<IMessageService>();

            // Act
            var conversationService = new ConversationService(
                mockedConversationRepository.Object,
                mockedUnitOfWork.Object,
                mockedConversationFactory.Object,
                mockedMessageService.Object);

            // Assert
            Assert.IsNotNull(conversationService);
            Assert.IsInstanceOf<ConversationService>(conversationService);
        }
    }
}
