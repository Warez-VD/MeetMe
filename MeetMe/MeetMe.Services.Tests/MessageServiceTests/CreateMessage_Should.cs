using System;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace MeetMe.Services.Tests.MessageServiceTests
{
    [TestFixture]
    public class CreateMessage_Should
    {
        [Test]
        public void CallDateTimeService_GetCurrentDateOnce()
        {
            // Arrange
            var mockedMessageRepository = new Mock<IEFRepository<Message>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMessageFactory = new Mock<IMessageFactory>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var date = new DateTime(2017, 2, 3);
            mockedDateTimeService.Setup(x => x.GetCurrentDate()).Returns(date);
            
            var messageService = new MessageService(
                mockedMessageRepository.Object,
                mockedUnitOfWork.Object,
                mockedMessageFactory.Object,
                mockedDateTimeService.Object);
            var user = new CustomUser();
            string content = "some content";

            // Act
            messageService.CreateMessage(user, content);

            // Assert
            mockedDateTimeService.Verify(x => x.GetCurrentDate(), Times.Once);
        }

        [Test]
        public void CallMessageFactory_CreateMessageOnce()
        {
            // Arrange
            var mockedMessageRepository = new Mock<IEFRepository<Message>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMessageFactory = new Mock<IMessageFactory>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var date = new DateTime(2017, 2, 3);
            mockedDateTimeService.Setup(x => x.GetCurrentDate()).Returns(date);

            var messageService = new MessageService(
                mockedMessageRepository.Object,
                mockedUnitOfWork.Object,
                mockedMessageFactory.Object,
                mockedDateTimeService.Object);
            var user = new CustomUser();
            string content = "some content";

            // Act
            messageService.CreateMessage(user, content);

            // Assert
            mockedMessageFactory.Verify(x => x.CreateMessage(content, user, date), Times.Once);
        }

        [Test]
        public void CallMessageRepository_AddOnce_WithCreatedMessage()
        {
            // Arrange
            var mockedMessageRepository = new Mock<IEFRepository<Message>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMessageFactory = new Mock<IMessageFactory>();
            var message = new Message();
            mockedMessageFactory.Setup(x => x.CreateMessage(It.IsAny<string>(), It.IsAny<CustomUser>(), It.IsAny<DateTime>())).Returns(message);
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var date = new DateTime(2017, 2, 3);
            mockedDateTimeService.Setup(x => x.GetCurrentDate()).Returns(date);

            var messageService = new MessageService(
                mockedMessageRepository.Object,
                mockedUnitOfWork.Object,
                mockedMessageFactory.Object,
                mockedDateTimeService.Object);
            var user = new CustomUser();
            string content = "some content";

            // Act
            messageService.CreateMessage(user, content);

            // Assert
            mockedMessageRepository.Verify(x => x.Add(message), Times.Once);
        }

        [Test]
        public void CallUnitOfWork_CommitOnce()
        {
            // Arrange
            var mockedMessageRepository = new Mock<IEFRepository<Message>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMessageFactory = new Mock<IMessageFactory>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var date = new DateTime(2017, 2, 3);
            mockedDateTimeService.Setup(x => x.GetCurrentDate()).Returns(date);

            var messageService = new MessageService(
                mockedMessageRepository.Object,
                mockedUnitOfWork.Object,
                mockedMessageFactory.Object,
                mockedDateTimeService.Object);
            var user = new CustomUser();
            string content = "some content";

            // Act
            messageService.CreateMessage(user, content);

            // Assert
            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void ReturnCreatedMessage_ByTheMessageFactory()
        {
            // Arrange
            var mockedMessageRepository = new Mock<IEFRepository<Message>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMessageFactory = new Mock<IMessageFactory>();
            var message = new Message();
            mockedMessageFactory.Setup(x => x.CreateMessage(It.IsAny<string>(), It.IsAny<CustomUser>(), It.IsAny<DateTime>())).Returns(message);
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var date = new DateTime(2017, 2, 3);
            mockedDateTimeService.Setup(x => x.GetCurrentDate()).Returns(date);

            var messageService = new MessageService(
                mockedMessageRepository.Object,
                mockedUnitOfWork.Object,
                mockedMessageFactory.Object,
                mockedDateTimeService.Object);
            var user = new CustomUser();
            string content = "some content";

            // Act
            var result = messageService.CreateMessage(user, content);

            // Assert
            Assert.AreEqual(message, result);
        }
    }
}
