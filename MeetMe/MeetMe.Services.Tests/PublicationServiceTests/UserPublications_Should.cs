using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Moq;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;

namespace MeetMe.Services.Tests.PublicationServiceTests
{
    [TestFixture]
    public class UserPublications_Should
    {
        [Test]
        public void CallUserService_GetByIndentityIdOnce()
        {
            // Arrange
            var mockedPublicationRepository = new Mock<IEFRepository<Publication>>();
            var mockedFriendsService = new Mock<IFriendService>();
            var mockedUserService = new Mock<IUserService>();
            var user = new CustomUser() { Publications = new List<Publication>() };
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
            string userId = "test-id";

            // Act
            publicationService.UserPublications(userId);

            // Assert
            mockedUserService.Verify(x => x.GetByIndentityId(It.Is<string>(i => i == userId)), Times.Once);
        }

        [Test]
        public void ReturnUserPublication_OrderedDescendingByDate()
        {
            // Arrange
            var mockedPublicationRepository = new Mock<IEFRepository<Publication>>();
            var mockedFriendsService = new Mock<IFriendService>();
            var mockedUserService = new Mock<IUserService>();
            var publications = new List<Publication>()
            {
                new Publication() { CreatedOn = new DateTime(1994, 12, 11) },
                new Publication() { CreatedOn = new DateTime(2004, 6, 21) },
                new Publication() { CreatedOn = new DateTime(2014, 1, 1) }
            }.OrderByDescending(x => x.CreatedOn).ToList();
            var user = new CustomUser() { Publications = publications };
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
            string userId = "test-id";

            // Act
            var result = publicationService.UserPublications(userId);

            // Assert
            CollectionAssert.AreEqual(result, publications);
        }
    }
}
