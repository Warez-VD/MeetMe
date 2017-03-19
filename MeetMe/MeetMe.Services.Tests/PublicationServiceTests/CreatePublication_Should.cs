using System;
using NUnit.Framework;
using Moq;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;

namespace MeetMe.Services.Tests.PublicationServiceTests
{
    [TestFixture]
    public class CreatePublication_Should
    {
        [Test]
        public void CallUserService_GetByIdentityIdOnce()
        {
            // Arrange
            var mockedPublicationRepository = new Mock<IEFRepository<Publication>>();
            var mockedFriendsService = new Mock<IFriendService>();
            var mockedUserService = new Mock<IUserService>();
            var user = new CustomUser() { Id = 1 };
            mockedUserService.Setup(x => x.GetByIndentityId(It.IsAny<string>())).Returns(user);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedPublicationFactory = new Mock<IPublicationFactory>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedPublicationImageFactory = new Mock<IPublicationImageFactory>();
            var mockedCommentService = new Mock<ICommentService>();

            var publicationService = new PublicationService(
                mockedPublicationRepository.Object,
                mockedFriendsService.Object,
                mockedUserService.Object,
                mockedUnitOfWork.Object,
                mockedPublicationFactory.Object,
                mockedDateTimeService.Object,
                mockedPublicationImageFactory.Object,
                mockedCommentService.Object);
            string content = "some content";
            string userId = "some-id";
            byte[] imageContent = new byte[] { 12, 43, 65, 12, 1, 45 };

            // Act
            publicationService.CreatePublication(content, userId, imageContent);

            // Assert
            mockedUserService.Verify(x => x.GetByIndentityId(It.Is<string>(i => i == userId)), Times.Once);
        }

        [Test]
        public void CallDateTimeService_GetCurrentTimeOnce()
        {
            // Arrange
            var mockedPublicationRepository = new Mock<IEFRepository<Publication>>();
            var mockedFriendsService = new Mock<IFriendService>();
            var mockedUserService = new Mock<IUserService>();
            var user = new CustomUser() { Id = 1 };
            mockedUserService.Setup(x => x.GetByIndentityId(It.IsAny<string>())).Returns(user);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedPublicationFactory = new Mock<IPublicationFactory>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedPublicationImageFactory = new Mock<IPublicationImageFactory>();
            var mockedCommentService = new Mock<ICommentService>();

            var publicationService = new PublicationService(
                mockedPublicationRepository.Object,
                mockedFriendsService.Object,
                mockedUserService.Object,
                mockedUnitOfWork.Object,
                mockedPublicationFactory.Object,
                mockedDateTimeService.Object,
                mockedPublicationImageFactory.Object,
                mockedCommentService.Object);
            string content = "some content";
            string userId = "some-id";
            byte[] imageContent = new byte[] { 12, 43, 65, 12, 1, 45 };

            // Act
            publicationService.CreatePublication(content, userId, imageContent);

            // Assert
            mockedDateTimeService.Verify(x => x.GetCurrentDate(), Times.Once);
        }

        [Test]
        public void CallPublicationImageFactory_CreatePublicationImageOnce()
        {
            // Arrange
            var mockedPublicationRepository = new Mock<IEFRepository<Publication>>();
            var mockedFriendsService = new Mock<IFriendService>();
            var mockedUserService = new Mock<IUserService>();
            var user = new CustomUser() { Id = 1 };
            mockedUserService.Setup(x => x.GetByIndentityId(It.IsAny<string>())).Returns(user);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedPublicationFactory = new Mock<IPublicationFactory>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedPublicationImageFactory = new Mock<IPublicationImageFactory>();
            var mockedCommentService = new Mock<ICommentService>();

            var publicationService = new PublicationService(
                mockedPublicationRepository.Object,
                mockedFriendsService.Object,
                mockedUserService.Object,
                mockedUnitOfWork.Object,
                mockedPublicationFactory.Object,
                mockedDateTimeService.Object,
                mockedPublicationImageFactory.Object,
                mockedCommentService.Object);
            string content = "some content";
            string userId = "some-id";
            byte[] imageContent = new byte[] { 12, 43, 65, 12, 1, 45 };

            // Act
            publicationService.CreatePublication(content, userId, imageContent);

            // Assert
            mockedPublicationImageFactory.Verify(x => x.CreatePublicationImage(It.Is<byte[]>(c => c == imageContent)), Times.Once);
        }

        [Test]
        public void CallPublicationFactory_CreatePublicationOnce()
        {
            // Arrange
            var mockedPublicationRepository = new Mock<IEFRepository<Publication>>();
            var mockedFriendsService = new Mock<IFriendService>();
            var mockedUserService = new Mock<IUserService>();
            var user = new CustomUser() { Id = 1 };
            mockedUserService.Setup(x => x.GetByIndentityId(It.IsAny<string>())).Returns(user);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedPublicationFactory = new Mock<IPublicationFactory>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var date = new DateTime(2004, 5, 20);
            mockedDateTimeService.Setup(x => x.GetCurrentDate()).Returns(date);
            var mockedPublicationImageFactory = new Mock<IPublicationImageFactory>();
            var image = new PublicationImage();
            mockedPublicationImageFactory.Setup(x => x.CreatePublicationImage(It.IsAny<byte[]>())).Returns(image);
            var mockedCommentService = new Mock<ICommentService>();

            var publicationService = new PublicationService(
                mockedPublicationRepository.Object,
                mockedFriendsService.Object,
                mockedUserService.Object,
                mockedUnitOfWork.Object,
                mockedPublicationFactory.Object,
                mockedDateTimeService.Object,
                mockedPublicationImageFactory.Object,
                mockedCommentService.Object);
            string content = "some content";
            string userId = "some-id";
            byte[] imageContent = new byte[] { 12, 43, 65, 12, 1, 45 };

            // Act
            publicationService.CreatePublication(content, userId, imageContent);

            // Assert
            mockedPublicationFactory
                .Verify(
                    x => x.CreatePublication(
                        It.Is<string>(c => c == content),
                        It.Is<int>(i => i == user.Id),
                        It.Is<DateTime>(d => d == date),
                        It.Is<PublicationImage>(p => p == image)),
                        Times.Once);
        }

        [Test]
        public void CallPublicationRepository_AddOnce()
        {
            // Arrange
            var mockedPublicationRepository = new Mock<IEFRepository<Publication>>();
            var mockedFriendsService = new Mock<IFriendService>();
            var mockedUserService = new Mock<IUserService>();
            var user = new CustomUser() { Id = 1 };
            mockedUserService.Setup(x => x.GetByIndentityId(It.IsAny<string>())).Returns(user);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedPublicationFactory = new Mock<IPublicationFactory>();
            var publication = new Publication();
            mockedPublicationFactory
                .Setup(
                    x => x.CreatePublication(
                        It.IsAny<string>(),
                        It.IsAny<int>(),
                        It.IsAny<DateTime>(),
                        It.IsAny<PublicationImage>())).Returns(publication);
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedPublicationImageFactory = new Mock<IPublicationImageFactory>();
            var mockedCommentService = new Mock<ICommentService>();

            var publicationService = new PublicationService(
                mockedPublicationRepository.Object,
                mockedFriendsService.Object,
                mockedUserService.Object,
                mockedUnitOfWork.Object,
                mockedPublicationFactory.Object,
                mockedDateTimeService.Object,
                mockedPublicationImageFactory.Object,
                mockedCommentService.Object);
            string content = "some content";
            string userId = "some-id";
            byte[] imageContent = new byte[] { 12, 43, 65, 12, 1, 45 };

            // Act
            publicationService.CreatePublication(content, userId, imageContent);

            // Assert
            mockedPublicationRepository.Verify(x => x.Add(It.Is<Publication>(p => p == publication)), Times.Once);
        }

        [Test]
        public void CallUnitOfWork_CommitOnce()
        {
            // Arrange
            var mockedPublicationRepository = new Mock<IEFRepository<Publication>>();
            var mockedFriendsService = new Mock<IFriendService>();
            var mockedUserService = new Mock<IUserService>();
            var user = new CustomUser() { Id = 1 };
            mockedUserService.Setup(x => x.GetByIndentityId(It.IsAny<string>())).Returns(user);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedPublicationFactory = new Mock<IPublicationFactory>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedPublicationImageFactory = new Mock<IPublicationImageFactory>();
            var mockedCommentService = new Mock<ICommentService>();

            var publicationService = new PublicationService(
                mockedPublicationRepository.Object,
                mockedFriendsService.Object,
                mockedUserService.Object,
                mockedUnitOfWork.Object,
                mockedPublicationFactory.Object,
                mockedDateTimeService.Object,
                mockedPublicationImageFactory.Object,
                mockedCommentService.Object);
            string content = "some content";
            string userId = "some-id";
            byte[] imageContent = new byte[] { 12, 43, 65, 12, 1, 45 };

            // Act
            publicationService.CreatePublication(content, userId, imageContent);

            // Assert
            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}
