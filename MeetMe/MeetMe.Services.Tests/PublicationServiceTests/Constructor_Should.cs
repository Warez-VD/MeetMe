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
            var mockedFriendsRepository = new Mock<IEFRepository<UserFriend>>();
            var mockedUserService = new Mock<IUserService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedPublicationFactory = new Mock<IPublicationFactory>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedPublicationImageFactory = new Mock<IPublicationImageFactory>();
            var mockedCommentService = new Mock<ICommentService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new PublicationService(
                null,
                mockedFriendsRepository.Object,
                mockedUserService.Object,
                mockedUnitOfWork.Object,
                mockedPublicationFactory.Object,
                mockedDateTimeService.Object,
                mockedPublicationImageFactory.Object,
                mockedCommentService.Object));

            // Assert
            Assert.That(ex.Message.Contains("PublicationRepository"));
        }

        [Test]
        public void ThrowsWhen_FriendsRepositoryIsNull()
        {
            // Arrange
            var mockedPublicationRepository = new Mock<IEFRepository<Publication>>();
            var mockedUserService = new Mock<IUserService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedPublicationFactory = new Mock<IPublicationFactory>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedPublicationImageFactory = new Mock<IPublicationImageFactory>();
            var mockedCommentService = new Mock<ICommentService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new PublicationService(
                mockedPublicationRepository.Object,
                null,
                mockedUserService.Object,
                mockedUnitOfWork.Object,
                mockedPublicationFactory.Object,
                mockedDateTimeService.Object,
                mockedPublicationImageFactory.Object,
                mockedCommentService.Object));

            // Assert
            Assert.That(ex.Message.Contains("FriendsRepository"));
        }

        [Test]
        public void ThrowsWhen_UserServiceIsNull()
        {
            // Arrange
            var mockedPublicationRepository = new Mock<IEFRepository<Publication>>();
            var mockedFriendsRepository = new Mock<IEFRepository<UserFriend>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedPublicationFactory = new Mock<IPublicationFactory>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedPublicationImageFactory = new Mock<IPublicationImageFactory>();
            var mockedCommentService = new Mock<ICommentService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new PublicationService(
                mockedPublicationRepository.Object,
                mockedFriendsRepository.Object,
                null,
                mockedUnitOfWork.Object,
                mockedPublicationFactory.Object,
                mockedDateTimeService.Object,
                mockedPublicationImageFactory.Object,
                mockedCommentService.Object));

            // Assert
            Assert.That(ex.Message.Contains("UserService"));
        }

        [Test]
        public void ThrowsWhen_UnitOfWorkIsNull()
        {
            // Arrange
            var mockedPublicationRepository = new Mock<IEFRepository<Publication>>();
            var mockedFriendsRepository = new Mock<IEFRepository<UserFriend>>();
            var mockedUserService = new Mock<IUserService>();
            var mockedPublicationFactory = new Mock<IPublicationFactory>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedPublicationImageFactory = new Mock<IPublicationImageFactory>();
            var mockedCommentService = new Mock<ICommentService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new PublicationService(
                mockedPublicationRepository.Object,
                mockedFriendsRepository.Object,
                mockedUserService.Object,
                null,
                mockedPublicationFactory.Object,
                mockedDateTimeService.Object,
                mockedPublicationImageFactory.Object,
                mockedCommentService.Object));

            // Assert
            Assert.That(ex.Message.Contains("UnitOfWork"));
        }

        [Test]
        public void ThrowsWhen_PublicationFactoryIsNull()
        {
            // Arrange
            var mockedPublicationRepository = new Mock<IEFRepository<Publication>>();
            var mockedFriendsRepository = new Mock<IEFRepository<UserFriend>>();
            var mockedUserService = new Mock<IUserService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedPublicationImageFactory = new Mock<IPublicationImageFactory>();
            var mockedCommentService = new Mock<ICommentService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new PublicationService(
                mockedPublicationRepository.Object,
                mockedFriendsRepository.Object,
                mockedUserService.Object,
                mockedUnitOfWork.Object,
                null,
                mockedDateTimeService.Object,
                mockedPublicationImageFactory.Object,
                mockedCommentService.Object));

            // Assert
            Assert.That(ex.Message.Contains("PublicationFactory"));
        }

        [Test]
        public void ThrowsWhen_DateTimeServiceIsNull()
        {
            // Arrange
            var mockedPublicationRepository = new Mock<IEFRepository<Publication>>();
            var mockedFriendsRepository = new Mock<IEFRepository<UserFriend>>();
            var mockedUserService = new Mock<IUserService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedPublicationFactory = new Mock<IPublicationFactory>();
            var mockedPublicationImageFactory = new Mock<IPublicationImageFactory>();
            var mockedCommentService = new Mock<ICommentService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new PublicationService(
                mockedPublicationRepository.Object,
                mockedFriendsRepository.Object,
                mockedUserService.Object,
                mockedUnitOfWork.Object,
                mockedPublicationFactory.Object,
                null,
                mockedPublicationImageFactory.Object,
                mockedCommentService.Object));

            // Assert
            Assert.That(ex.Message.Contains("DateTimeService"));
        }

        [Test]
        public void ThrowsWhen_PublicationImageFactoryIsNull()
        {
            // Arrange
            var mockedPublicationRepository = new Mock<IEFRepository<Publication>>();
            var mockedFriendsRepository = new Mock<IEFRepository<UserFriend>>();
            var mockedUserService = new Mock<IUserService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedPublicationFactory = new Mock<IPublicationFactory>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedCommentService = new Mock<ICommentService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new PublicationService(
                mockedPublicationRepository.Object,
                mockedFriendsRepository.Object,
                mockedUserService.Object,
                mockedUnitOfWork.Object,
                mockedPublicationFactory.Object,
                mockedDateTimeService.Object,
                null,
                mockedCommentService.Object));

            // Assert
            Assert.That(ex.Message.Contains("PublicationImageFactory"));
        }

        [Test]
        public void ThrowsWhen_CommentServiceIsNull()
        {
            // Arrange
            var mockedPublicationRepository = new Mock<IEFRepository<Publication>>();
            var mockedFriendsRepository = new Mock<IEFRepository<UserFriend>>();
            var mockedUserService = new Mock<IUserService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedPublicationFactory = new Mock<IPublicationFactory>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedPublicationImageFactory = new Mock<IPublicationImageFactory>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new PublicationService(
                mockedPublicationRepository.Object,
                mockedFriendsRepository.Object,
                mockedUserService.Object,
                mockedUnitOfWork.Object,
                mockedPublicationFactory.Object,
                mockedDateTimeService.Object,
                mockedPublicationImageFactory.Object,
                null));

            // Assert
            Assert.That(ex.Message.Contains("CommentService"));
        }

        [Test]
        public void ReturnInstanceOfPublicationService_Correct()
        {
            // Arrange
            var mockedPublicationRepository = new Mock<IEFRepository<Publication>>();
            var mockedFriendsRepository = new Mock<IEFRepository<UserFriend>>();
            var mockedUserService = new Mock<IUserService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedPublicationFactory = new Mock<IPublicationFactory>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedPublicationImageFactory = new Mock<IPublicationImageFactory>();
            var mockedCommentService = new Mock<ICommentService>();

            // Act
            var publicationService = new PublicationService(
                mockedPublicationRepository.Object,
                mockedFriendsRepository.Object,
                mockedUserService.Object,
                mockedUnitOfWork.Object,
                mockedPublicationFactory.Object,
                mockedDateTimeService.Object,
                mockedPublicationImageFactory.Object,
                mockedCommentService.Object);

            // Assert
            Assert.IsNotNull(publicationService);
            Assert.IsInstanceOf<PublicationService>(publicationService);
        }
    }
}
