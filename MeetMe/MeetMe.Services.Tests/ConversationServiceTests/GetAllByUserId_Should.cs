using System.Collections.Generic;
using System.Linq;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace MeetMe.Services.Tests.ConversationServiceTests
{
    [TestFixture]
    public class GetAllByUserId_Should
    {
        [Test]
        public void ReturnAllConversations_WhenContainingUserId()
        {
            // Arrange
            string userId = "user-id-xx";

            var mockedConversationRepository = new Mock<IEFRepository<Conversation>>();
            var conversations = new List<Conversation>()
            {
                new Conversation() { FirstUserId = "1", SecondUserId = userId },
                new Conversation() { FirstUserId = "2", SecondUserId = "1" },
                new Conversation() { FirstUserId = userId, SecondUserId = "5" },
                new Conversation() { FirstUserId = "1", SecondUserId = "5" },
                new Conversation() { FirstUserId = "51", SecondUserId = "10" },
            }.AsQueryable();
            mockedConversationRepository.Setup(x => x.All).Returns(conversations);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedConversationFactory = new Mock<IConversationFactory>();
            var mockedMessageService = new Mock<IMessageService>();

            var conversationService = new ConversationService(
                mockedConversationRepository.Object,
                mockedUnitOfWork.Object,
                mockedConversationFactory.Object,
                mockedMessageService.Object);
            
            // Act
            var result = conversationService.GetAllByUserId(userId);

            // Assert
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public void ReturnEmptyCollection_WhenDontContainingUserId()
        {
            // Arrange
            string userId = "user-id-xx";

            var mockedConversationRepository = new Mock<IEFRepository<Conversation>>();
            var conversations = new List<Conversation>()
            {
                new Conversation() { FirstUserId = "1", SecondUserId = "10" },
                new Conversation() { FirstUserId = "2", SecondUserId = "1" },
                new Conversation() { FirstUserId = "22", SecondUserId = "5" },
                new Conversation() { FirstUserId = "1", SecondUserId = "5" },
                new Conversation() { FirstUserId = "51", SecondUserId = "10" },
            }.AsQueryable();
            mockedConversationRepository.Setup(x => x.All).Returns(conversations);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedConversationFactory = new Mock<IConversationFactory>();
            var mockedMessageService = new Mock<IMessageService>();

            var conversationService = new ConversationService(
                mockedConversationRepository.Object,
                mockedUnitOfWork.Object,
                mockedConversationFactory.Object,
                mockedMessageService.Object);

            // Act
            var result = conversationService.GetAllByUserId(userId);

            // Assert
            CollectionAssert.IsEmpty(result);
        }
    }
}
