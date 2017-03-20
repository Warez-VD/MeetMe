using System;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace MeetMe.Services.Tests.PublicationServiceTests
{
    [TestFixture]
    public class CreatePublicationComment_Should
    {
        [Test]
        public void CallPublicationRepository_GetByIdOnce()
        {
            // Arrange
            var mockedPublicationRepository = new Mock<IEFRepository<Publication>>();
            var publication = new Publication();
            mockedPublicationRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(publication);
            var mockedFriendsService = new Mock<IFriendService>();
            var mockedUserService = new Mock<IUserService>();
            var user = new CustomUser();
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
            int publicationId = 12;
            string content = "some content";
            string userId = "test-id";

            // Act
            publicationService.CreatePublicationComment(publicationId, content, userId);

            // Assert
            mockedPublicationRepository.Verify(x => x.GetById(It.Is<int>(i => i == publicationId)), Times.Once);
        }

        [Test]
        public void CallUserService_GetByIndentityIdOnce()
        {
            // Arrange
            var mockedPublicationRepository = new Mock<IEFRepository<Publication>>();
            var publication = new Publication();
            mockedPublicationRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(publication);
            var mockedFriendsService = new Mock<IFriendService>();
            var mockedUserService = new Mock<IUserService>();
            var user = new CustomUser();
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
            int publicationId = 12;
            string content = "some content";
            string userId = "test-id";

            // Act
            publicationService.CreatePublicationComment(publicationId, content, userId);

            // Assert
            mockedUserService.Verify(x => x.GetByIndentityId(It.Is<string>(i => i == userId)), Times.Once);
        }

        [Test]
        public void CallDateTimeService_GetCurrentDateOnce()
        {
            // Arrange
            var mockedPublicationRepository = new Mock<IEFRepository<Publication>>();
            var publication = new Publication();
            mockedPublicationRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(publication);
            var mockedFriendsService = new Mock<IFriendService>();
            var mockedUserService = new Mock<IUserService>();
            var user = new CustomUser();
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
            int publicationId = 12;
            string content = "some content";
            string userId = "test-id";

            // Act
            publicationService.CreatePublicationComment(publicationId, content, userId);

            // Assert
            mockedDateTimeService.Verify(x => x.GetCurrentDate(), Times.Once);
        }

        [Test]
        public void CallCommentService_CreatePublicationCommentOnce()
        {
            // Arrange
            var mockedPublicationRepository = new Mock<IEFRepository<Publication>>();
            var publication = new Publication();
            mockedPublicationRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(publication);
            var mockedFriendsService = new Mock<IFriendService>();
            var mockedUserService = new Mock<IUserService>();
            var user = new CustomUser() { Id = 14 };
            mockedUserService.Setup(x => x.GetByIndentityId(It.IsAny<string>())).Returns(user);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedPublicationFactory = new Mock<IPublicationFactory>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var date = new DateTime(2015, 10, 4);
            mockedDateTimeService.Setup(x => x.GetCurrentDate()).Returns(date);
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
            int publicationId = 12;
            string content = "some content";
            string userId = "test-id";

            // Act
            publicationService.CreatePublicationComment(publicationId, content, userId);

            // Assert
            mockedCommentService
                .Verify(
                    x => x.CreatePublicationComment(
                        It.Is<string>(c => c == content),
                        It.Is<int>(i => i == user.Id),
                        It.Is<DateTime>(d => d == date)),
                        Times.Once);
        }

        [Test]
        public void AddCommentToPublicationCollection()
        {
            // Arrange
            var mockedPublicationRepository = new Mock<IEFRepository<Publication>>();
            var publication = new Publication();
            mockedPublicationRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(publication);
            var mockedFriendsService = new Mock<IFriendService>();
            var mockedUserService = new Mock<IUserService>();
            var user = new CustomUser() { Id = 14 };
            mockedUserService.Setup(x => x.GetByIndentityId(It.IsAny<string>())).Returns(user);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedPublicationFactory = new Mock<IPublicationFactory>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedPublicationImageFactory = new Mock<IPublicationImageFactory>();
            var mockedCommentService = new Mock<ICommentService>();
            var comment = new Comment();
            mockedCommentService.Setup(x => x.CreatePublicationComment(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<DateTime>())).Returns(comment);

            var publicationService = new PublicationService(
                mockedPublicationRepository.Object,
                mockedFriendsService.Object,
                mockedUserService.Object,
                mockedUnitOfWork.Object,
                mockedPublicationFactory.Object,
                mockedDateTimeService.Object,
                mockedPublicationImageFactory.Object,
                mockedCommentService.Object);
            int publicationId = 12;
            string content = "some content";
            string userId = "test-id";

            // Act
            publicationService.CreatePublicationComment(publicationId, content, userId);

            // Assert
            Assert.That(publication.Comments.Contains(comment));
        }

        [Test]
        public void CallPublicationRepository_UpdateOnce()
        {
            // Arrange
            var mockedPublicationRepository = new Mock<IEFRepository<Publication>>();
            var publication = new Publication();
            mockedPublicationRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(publication);
            var mockedFriendsService = new Mock<IFriendService>();
            var mockedUserService = new Mock<IUserService>();
            var user = new CustomUser() { Id = 14 };
            mockedUserService.Setup(x => x.GetByIndentityId(It.IsAny<string>())).Returns(user);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedPublicationFactory = new Mock<IPublicationFactory>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedPublicationImageFactory = new Mock<IPublicationImageFactory>();
            var mockedCommentService = new Mock<ICommentService>();
            var comment = new Comment();
            mockedCommentService.Setup(x => x.CreatePublicationComment(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<DateTime>())).Returns(comment);

            var publicationService = new PublicationService(
                mockedPublicationRepository.Object,
                mockedFriendsService.Object,
                mockedUserService.Object,
                mockedUnitOfWork.Object,
                mockedPublicationFactory.Object,
                mockedDateTimeService.Object,
                mockedPublicationImageFactory.Object,
                mockedCommentService.Object);
            int publicationId = 12;
            string content = "some content";
            string userId = "test-id";

            // Act
            publicationService.CreatePublicationComment(publicationId, content, userId);

            // Assert
            mockedPublicationRepository.Verify(x => x.Update(It.Is<Publication>(p => p == publication)), Times.Once);
        }

        [Test]
        public void CallUnitOfWork_CommitOnce()
        {
            // Arrange
            var mockedPublicationRepository = new Mock<IEFRepository<Publication>>();
            var publication = new Publication();
            mockedPublicationRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(publication);
            var mockedFriendsService = new Mock<IFriendService>();
            var mockedUserService = new Mock<IUserService>();
            var user = new CustomUser() { Id = 14 };
            mockedUserService.Setup(x => x.GetByIndentityId(It.IsAny<string>())).Returns(user);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedPublicationFactory = new Mock<IPublicationFactory>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedPublicationImageFactory = new Mock<IPublicationImageFactory>();
            var mockedCommentService = new Mock<ICommentService>();
            var comment = new Comment();
            mockedCommentService.Setup(x => x.CreatePublicationComment(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<DateTime>())).Returns(comment);

            var publicationService = new PublicationService(
                mockedPublicationRepository.Object,
                mockedFriendsService.Object,
                mockedUserService.Object,
                mockedUnitOfWork.Object,
                mockedPublicationFactory.Object,
                mockedDateTimeService.Object,
                mockedPublicationImageFactory.Object,
                mockedCommentService.Object);
            int publicationId = 12;
            string content = "some content";
            string userId = "test-id";

            // Act
            publicationService.CreatePublicationComment(publicationId, content, userId);

            // Assert
            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}
