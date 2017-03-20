using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace MeetMe.Services.Tests.PublicationServiceTests
{
    [TestFixture]
    public class AddDislike_Should
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

            // Act
            publicationService.AddDislike(publicationId);

            // Assert
            mockedPublicationRepository.Verify(x => x.GetById(It.Is<int>(i => i == publicationId)), Times.Once);
        }

        [Test]
        public void IncreasePublicationDislikes_WithOne()
        {
            // Arrange
            var mockedPublicationRepository = new Mock<IEFRepository<Publication>>();
            var publication = new Publication();
            mockedPublicationRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(publication);
            var mockedFriendsService = new Mock<IFriendService>();
            var mockedUserService = new Mock<IUserService>();
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

            // Act
            publicationService.AddDislike(publicationId);

            // Assert
            Assert.AreEqual(publication.Dislikes, 1);
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

            // Act
            publicationService.AddDislike(publicationId);

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

            // Act
            publicationService.AddDislike(publicationId);

            // Assert
            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}
