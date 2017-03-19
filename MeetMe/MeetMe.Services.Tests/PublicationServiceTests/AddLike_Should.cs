using NUnit.Framework;
using Moq;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;

namespace MeetMe.Services.Tests.PublicationServiceTests
{
    [TestFixture]
    public class AddLike_Should
    {
        [Test]
        public void CallPublicationRepository_GetByIdOnce()
        {
            // Arrange
            var mockedPublicationRepository = new Mock<IEFRepository<Publication>>();
            var publication = new Publication();
            mockedPublicationRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(publication);
            var mockedFriendsRepository = new Mock<IEFRepository<UserFriend>>();
            var mockedUserService = new Mock<IUserService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedPublicationFactory = new Mock<IPublicationFactory>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedPublicationImageFactory = new Mock<IPublicationImageFactory>();
            var mockedCommentService = new Mock<ICommentService>();

            var publicationService = new PublicationService(
                mockedPublicationRepository.Object,
                mockedFriendsRepository.Object,
                mockedUserService.Object,
                mockedUnitOfWork.Object,
                mockedPublicationFactory.Object,
                mockedDateTimeService.Object,
                mockedPublicationImageFactory.Object,
                mockedCommentService.Object);
            int publicationId = 12;

            // Act
            publicationService.AddLike(publicationId);

            // Assert
            mockedPublicationRepository.Verify(x => x.GetById(It.Is<int>(i => i == publicationId)), Times.Once);
        }

        [Test]
        public void IncreasePublicationLikes_WithOne()
        {
            // Arrange
            var mockedPublicationRepository = new Mock<IEFRepository<Publication>>();
            var publication = new Publication();
            mockedPublicationRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(publication);
            var mockedFriendsRepository = new Mock<IEFRepository<UserFriend>>();
            var mockedUserService = new Mock<IUserService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedPublicationFactory = new Mock<IPublicationFactory>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedPublicationImageFactory = new Mock<IPublicationImageFactory>();
            var mockedCommentService = new Mock<ICommentService>();

            var publicationService = new PublicationService(
                mockedPublicationRepository.Object,
                mockedFriendsRepository.Object,
                mockedUserService.Object,
                mockedUnitOfWork.Object,
                mockedPublicationFactory.Object,
                mockedDateTimeService.Object,
                mockedPublicationImageFactory.Object,
                mockedCommentService.Object);
            int publicationId = 12;

            // Act
            publicationService.AddLike(publicationId);

            // Assert
            Assert.AreEqual(publication.Likes, 1);
        }

        [Test]
        public void CallPublicationRepository_UpdateOnce()
        {
            // Arrange
            var mockedPublicationRepository = new Mock<IEFRepository<Publication>>();
            var publication = new Publication();
            mockedPublicationRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(publication);
            var mockedFriendsRepository = new Mock<IEFRepository<UserFriend>>();
            var mockedUserService = new Mock<IUserService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedPublicationFactory = new Mock<IPublicationFactory>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedPublicationImageFactory = new Mock<IPublicationImageFactory>();
            var mockedCommentService = new Mock<ICommentService>();

            var publicationService = new PublicationService(
                mockedPublicationRepository.Object,
                mockedFriendsRepository.Object,
                mockedUserService.Object,
                mockedUnitOfWork.Object,
                mockedPublicationFactory.Object,
                mockedDateTimeService.Object,
                mockedPublicationImageFactory.Object,
                mockedCommentService.Object);
            int publicationId = 12;

            // Act
            publicationService.AddLike(publicationId);

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
            var mockedFriendsRepository = new Mock<IEFRepository<UserFriend>>();
            var mockedUserService = new Mock<IUserService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedPublicationFactory = new Mock<IPublicationFactory>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedPublicationImageFactory = new Mock<IPublicationImageFactory>();
            var mockedCommentService = new Mock<ICommentService>();

            var publicationService = new PublicationService(
                mockedPublicationRepository.Object,
                mockedFriendsRepository.Object,
                mockedUserService.Object,
                mockedUnitOfWork.Object,
                mockedPublicationFactory.Object,
                mockedDateTimeService.Object,
                mockedPublicationImageFactory.Object,
                mockedCommentService.Object);
            int publicationId = 12;

            // Act
            publicationService.AddLike(publicationId);

            // Assert
            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}
