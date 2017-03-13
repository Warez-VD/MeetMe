using System;
using NUnit.Framework;
using Moq;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;

namespace MeetMe.Services.Tests.PublicationServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhen_PublicationRepositoryIsNull()
        {
            // Arrange
            var mockedCommentRepository = new Mock<IEFRepository<Comment>>();
            var mockedUserService = new Mock<IUserService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedPublicationFactory = new Mock<IPublicationFactory>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedPublicationImageFactory = new Mock<IPublicationImageFactory>();
            var mockedCommentFactory = new Mock<ICommentFactory>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new PublicationService(
                null,
                mockedCommentRepository.Object,
                mockedUserService.Object,
                mockedUnitOfWork.Object,
                mockedPublicationFactory.Object,
                mockedDateTimeService.Object,
                mockedPublicationImageFactory.Object,
                mockedCommentFactory.Object));

            // Assert
            Assert.That(ex.Message.Contains("PublicationRepository"));
        }

        [Test]
        public void ThrowsWhen_CommentRepositoryIsNull()
        {
            // Arrange
            var mockedPublicationRepository = new Mock<IEFRepository<Publication>>();
            var mockedUserService = new Mock<IUserService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedPublicationFactory = new Mock<IPublicationFactory>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedPublicationImageFactory = new Mock<IPublicationImageFactory>();
            var mockedCommentFactory = new Mock<ICommentFactory>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new PublicationService(
                mockedPublicationRepository.Object,
                null,
                mockedUserService.Object,
                mockedUnitOfWork.Object,
                mockedPublicationFactory.Object,
                mockedDateTimeService.Object,
                mockedPublicationImageFactory.Object,
                mockedCommentFactory.Object));

            // Assert
            Assert.That(ex.Message.Contains("CommentRepository"));
        }

        [Test]
        public void ThrowsWhen_UserServiceIsNull()
        {
            // Arrange
            var mockedPublicationRepository = new Mock<IEFRepository<Publication>>();
            var mockedCommentRepository = new Mock<IEFRepository<Comment>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedPublicationFactory = new Mock<IPublicationFactory>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedPublicationImageFactory = new Mock<IPublicationImageFactory>();
            var mockedCommentFactory = new Mock<ICommentFactory>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new PublicationService(
                mockedPublicationRepository.Object,
                mockedCommentRepository.Object,
                null,
                mockedUnitOfWork.Object,
                mockedPublicationFactory.Object,
                mockedDateTimeService.Object,
                mockedPublicationImageFactory.Object,
                mockedCommentFactory.Object));

            // Assert
            Assert.That(ex.Message.Contains("UserService"));
        }

        [Test]
        public void ThrowsWhen_UnitOfWorkIsNull()
        {
            // Arrange
            var mockedPublicationRepository = new Mock<IEFRepository<Publication>>();
            var mockedCommentRepository = new Mock<IEFRepository<Comment>>();
            var mockedUserService = new Mock<IUserService>();
            var mockedPublicationFactory = new Mock<IPublicationFactory>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedPublicationImageFactory = new Mock<IPublicationImageFactory>();
            var mockedCommentFactory = new Mock<ICommentFactory>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new PublicationService(
                mockedPublicationRepository.Object,
                mockedCommentRepository.Object,
                mockedUserService.Object,
                null,
                mockedPublicationFactory.Object,
                mockedDateTimeService.Object,
                mockedPublicationImageFactory.Object,
                mockedCommentFactory.Object));

            // Assert
            Assert.That(ex.Message.Contains("UnitOfWork"));
        }

        [Test]
        public void ThrowsWhen_PublicationFactoryIsNull()
        {
            // Arrange
            var mockedPublicationRepository = new Mock<IEFRepository<Publication>>();
            var mockedCommentRepository = new Mock<IEFRepository<Comment>>();
            var mockedUserService = new Mock<IUserService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedPublicationImageFactory = new Mock<IPublicationImageFactory>();
            var mockedCommentFactory = new Mock<ICommentFactory>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new PublicationService(
                mockedPublicationRepository.Object,
                mockedCommentRepository.Object,
                mockedUserService.Object,
                mockedUnitOfWork.Object,
                null,
                mockedDateTimeService.Object,
                mockedPublicationImageFactory.Object,
                mockedCommentFactory.Object));

            // Assert
            Assert.That(ex.Message.Contains("PublicationFactory"));
        }

        [Test]
        public void ThrowsWhen_DateTimeServiceIsNull()
        {
            // Arrange
            var mockedPublicationRepository = new Mock<IEFRepository<Publication>>();
            var mockedCommentRepository = new Mock<IEFRepository<Comment>>();
            var mockedUserService = new Mock<IUserService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedPublicationFactory = new Mock<IPublicationFactory>();
            var mockedPublicationImageFactory = new Mock<IPublicationImageFactory>();
            var mockedCommentFactory = new Mock<ICommentFactory>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new PublicationService(
                mockedPublicationRepository.Object,
                mockedCommentRepository.Object,
                mockedUserService.Object,
                mockedUnitOfWork.Object,
                mockedPublicationFactory.Object,
                null,
                mockedPublicationImageFactory.Object,
                mockedCommentFactory.Object));

            // Assert
            Assert.That(ex.Message.Contains("DateTimeService"));
        }

        [Test]
        public void ThrowsWhen_PublicationImageFactoryIsNull()
        {
            // Arrange
            var mockedPublicationRepository = new Mock<IEFRepository<Publication>>();
            var mockedCommentRepository = new Mock<IEFRepository<Comment>>();
            var mockedUserService = new Mock<IUserService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedPublicationFactory = new Mock<IPublicationFactory>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedCommentFactory = new Mock<ICommentFactory>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new PublicationService(
                mockedPublicationRepository.Object,
                mockedCommentRepository.Object,
                mockedUserService.Object,
                mockedUnitOfWork.Object,
                mockedPublicationFactory.Object,
                mockedDateTimeService.Object,
                null,
                mockedCommentFactory.Object));

            // Assert
            Assert.That(ex.Message.Contains("PublicationImageFactory"));
        }

        [Test]
        public void ThrowsWhen_CommentFactoryIsNull()
        {
            // Arrange
            var mockedPublicationRepository = new Mock<IEFRepository<Publication>>();
            var mockedCommentRepository = new Mock<IEFRepository<Comment>>();
            var mockedUserService = new Mock<IUserService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedPublicationFactory = new Mock<IPublicationFactory>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedPublicationImageFactory = new Mock<IPublicationImageFactory>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new PublicationService(
                mockedPublicationRepository.Object,
                mockedCommentRepository.Object,
                mockedUserService.Object,
                mockedUnitOfWork.Object,
                mockedPublicationFactory.Object,
                mockedDateTimeService.Object,
                mockedPublicationImageFactory.Object,
                null));

            // Assert
            Assert.That(ex.Message.Contains("CommentFactory"));
        }

        [Test]
        public void ReturnInstanceOfPublicationService_Correct()
        {
            // Arrange
            var mockedPublicationRepository = new Mock<IEFRepository<Publication>>();
            var mockedCommentRepository = new Mock<IEFRepository<Comment>>();
            var mockedUserService = new Mock<IUserService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedPublicationFactory = new Mock<IPublicationFactory>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedPublicationImageFactory = new Mock<IPublicationImageFactory>();
            var mockedCommentFactory = new Mock<ICommentFactory>();

            // Act
            var publicationService = new PublicationService(
                mockedPublicationRepository.Object,
                mockedCommentRepository.Object,
                mockedUserService.Object,
                mockedUnitOfWork.Object,
                mockedPublicationFactory.Object,
                mockedDateTimeService.Object,
                mockedPublicationImageFactory.Object,
                mockedCommentFactory.Object);

            // Assert
            Assert.IsNotNull(publicationService);
            Assert.IsInstanceOf<PublicationService>(publicationService);
        }
    }
}
