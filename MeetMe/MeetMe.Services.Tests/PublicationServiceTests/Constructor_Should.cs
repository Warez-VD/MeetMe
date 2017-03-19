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
            var mockedFriendsService = new Mock<IFriendService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedPublicationFactory = new Mock<IPublicationFactory>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedPublicationImageFactory = new Mock<IPublicationImageFactory>();
            var mockedCommentService = new Mock<ICommentService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new PublicationService(
                null,
                mockedFriendsService.Object,
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
        public void ThrowsWhen_FriendsServiceIsNull()
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
            Assert.That(ex.Message.Contains("FriendService"));
        }

        [Test]
        public void ThrowsWhen_UserServiceIsNull()
        {
            // Arrange
            var mockedPublicationRepository = new Mock<IEFRepository<Publication>>();
            var mockedFriendsService = new Mock<IFriendService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedPublicationFactory = new Mock<IPublicationFactory>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedPublicationImageFactory = new Mock<IPublicationImageFactory>();
            var mockedCommentService = new Mock<ICommentService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new PublicationService(
                mockedPublicationRepository.Object,
                mockedFriendsService.Object,
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
            var mockedFriendsService = new Mock<IFriendService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedPublicationFactory = new Mock<IPublicationFactory>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedPublicationImageFactory = new Mock<IPublicationImageFactory>();
            var mockedCommentService = new Mock<ICommentService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new PublicationService(
                mockedPublicationRepository.Object,
                mockedFriendsService.Object,
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
            var mockedFriendsService = new Mock<IFriendService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedPublicationImageFactory = new Mock<IPublicationImageFactory>();
            var mockedCommentService = new Mock<ICommentService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new PublicationService(
                mockedPublicationRepository.Object,
                mockedFriendsService.Object,
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
            var mockedFriendsService = new Mock<IFriendService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedPublicationFactory = new Mock<IPublicationFactory>();
            var mockedPublicationImageFactory = new Mock<IPublicationImageFactory>();
            var mockedCommentService = new Mock<ICommentService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new PublicationService(
                mockedPublicationRepository.Object,
                mockedFriendsService.Object,
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
            var mockedFriendsService = new Mock<IFriendService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedPublicationFactory = new Mock<IPublicationFactory>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedCommentService = new Mock<ICommentService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new PublicationService(
                mockedPublicationRepository.Object,
                mockedFriendsService.Object,
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
            var mockedFriendsService = new Mock<IFriendService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedPublicationFactory = new Mock<IPublicationFactory>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedPublicationImageFactory = new Mock<IPublicationImageFactory>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new PublicationService(
                mockedPublicationRepository.Object,
                mockedFriendsService.Object,
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
            var mockedFriendsService = new Mock<IFriendService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedPublicationFactory = new Mock<IPublicationFactory>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedPublicationImageFactory = new Mock<IPublicationImageFactory>();
            var mockedCommentService = new Mock<ICommentService>();

            // Act
            var publicationService = new PublicationService(
                mockedPublicationRepository.Object,
                mockedFriendsService.Object,
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
