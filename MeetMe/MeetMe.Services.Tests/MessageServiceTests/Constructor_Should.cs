using System;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace MeetMe.Services.Tests.MessageServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhen_MessageRepositoryIsNull()
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMessageFactory = new Mock<IMessageFactory>();
            var mockedDateTimeService = new Mock<IDateTimeService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new MessageService(
                null,
                mockedUnitOfWork.Object,
                mockedMessageFactory.Object,
                mockedDateTimeService.Object));

            // Assert
            Assert.That(ex.Message.Contains("MessageRepository"));
        }

        [Test]
        public void ThrowsWhen_UnitOfWorkIsNull()
        {
            // Arrange
            var mockedMessageRepository = new Mock<IEFRepository<Message>>();
            var mockedMessageFactory = new Mock<IMessageFactory>();
            var mockedDateTimeService = new Mock<IDateTimeService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new MessageService(
                mockedMessageRepository.Object,
                null,
                mockedMessageFactory.Object,
                mockedDateTimeService.Object));

            // Assert
            Assert.That(ex.Message.Contains("UnitOfWork"));
        }

        [Test]
        public void ThrowsWhen_MessageFactoryIsNull()
        {
            // Arrange
            var mockedMessageRepository = new Mock<IEFRepository<Message>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedDateTimeService = new Mock<IDateTimeService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new MessageService(
                mockedMessageRepository.Object,
                mockedUnitOfWork.Object,
                null,
                mockedDateTimeService.Object));

            // Assert
            Assert.That(ex.Message.Contains("MessageFactory"));
        }

        [Test]
        public void ThrowsWhen_DateTimeServiceIsNull()
        {
            // Arrange
            var mockedMessageRepository = new Mock<IEFRepository<Message>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMessageFactory = new Mock<IMessageFactory>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new MessageService(
                mockedMessageRepository.Object,
                mockedUnitOfWork.Object,
                mockedMessageFactory.Object,
                null));

            // Assert
            Assert.That(ex.Message.Contains("DateTimeService"));
        }

        [Test]
        public void ReturnInstanceOfAccountService_Correct()
        {
            // Arrange
            var mockedMessageRepository = new Mock<IEFRepository<Message>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMessageFactory = new Mock<IMessageFactory>();
            var mockedDateTimeService = new Mock<IDateTimeService>();

            // Act
            var messageService = new MessageService(
                mockedMessageRepository.Object,
                mockedUnitOfWork.Object,
                mockedMessageFactory.Object,
                mockedDateTimeService.Object);

            // Assert
            Assert.IsNotNull(messageService);
            Assert.IsInstanceOf<MessageService>(messageService);
        }
    }
}
