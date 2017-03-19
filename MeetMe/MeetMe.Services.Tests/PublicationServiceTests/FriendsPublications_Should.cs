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
    public class FriendsPublications_Should
    {
        [Test]
        public void CallUserService_GetByIndentityIdOnce()
        {
            // Arrange
            var mockedPublicationRepository = new Mock<IEFRepository<Publication>>();
            var mockedFriendService = new Mock<IFriendService>();
            var friendIds = new List<int>() { 1, 2 };
            mockedFriendService.Setup(x => x.GetAllUserFriendsIds(It.IsAny<int>())).Returns(friendIds);
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
                mockedFriendService.Object,
                mockedUserService.Object,
                mockedUnitOfWork.Object,
                mockedPublicationFactory.Object,
                mockedDateTimeService.Object,
                mockedPublicationImageFactory.Object,
                mockedCommentService.Object);
            string userId = "user-xx-id";
            int skip = 0;
            int count = 2;

            // Act
            publicationService.FriendsPublications(userId, skip, count);

            // Assert
            mockedUserService.Verify(x => x.GetByIndentityId(It.Is<string>(i => i == userId)), Times.Once);
        }

        [Test]
        public void GetFriendsIdsToAddCurrentUserId()
        {
            // Arrange
            var mockedPublicationRepository = new Mock<IEFRepository<Publication>>();
            var mockedFriendService = new Mock<IFriendService>();
            var friends = new List<int>() { 2, 3 };
            mockedFriendService.Setup(x => x.GetAllUserFriendsIds(It.IsAny<int>())).Returns(friends);
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
                mockedFriendService.Object,
                mockedUserService.Object,
                mockedUnitOfWork.Object,
                mockedPublicationFactory.Object,
                mockedDateTimeService.Object,
                mockedPublicationImageFactory.Object,
                mockedCommentService.Object);
            string userId = "user-xx-id";
            int skip = 0;
            int count = 2;
            var expected = new List<int>() { 2, 3, user.Id };

            // Act
            publicationService.FriendsPublications(userId, skip, count);

            // Assert
            CollectionAssert.AreEqual(expected, friends);
        }

        [Test]
        public void GetCorrectCountPublication()
        {
            // Arrange
            var mockedPublicationRepository = new Mock<IEFRepository<Publication>>();
            var publications = new List<Publication>()
            {
                new Publication() { Author = new CustomUser() { Id = 1 }, CreatedOn = new DateTime(2016, 10, 12) },
                new Publication() { Author = new CustomUser() { Id = 1 }, CreatedOn = new DateTime(2016, 10, 13) },
                new Publication() { Author = new CustomUser() { Id = 2 }, CreatedOn = new DateTime(2016, 10, 12) },
                new Publication() { Author = new CustomUser() { Id = 3 }, CreatedOn = new DateTime(2016, 10, 15) }
            }.AsQueryable();
            mockedPublicationRepository.Setup(x => x.All).Returns(publications);

            var mockedFriendService = new Mock<IFriendService>();
            var friends = new List<int>() { 2, 3 };
            mockedFriendService.Setup(x => x.GetAllUserFriendsIds(It.IsAny<int>())).Returns(friends);
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
                mockedFriendService.Object,
                mockedUserService.Object,
                mockedUnitOfWork.Object,
                mockedPublicationFactory.Object,
                mockedDateTimeService.Object,
                mockedPublicationImageFactory.Object,
                mockedCommentService.Object);
            string userId = "user-xx-id";
            int skip = 0;
            int count = 2;

            // Act
            var result = publicationService.FriendsPublications(userId, skip, count);

            // Assert
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public void GetCorrectCountPublication_WhenSkip()
        {
            // Arrange
            var mockedPublicationRepository = new Mock<IEFRepository<Publication>>();
            var publications = new List<Publication>()
            {
                new Publication() { Author = new CustomUser() { Id = 1 }, CreatedOn = new DateTime(2016, 10, 12) },
                new Publication() { Author = new CustomUser() { Id = 1 }, CreatedOn = new DateTime(2016, 10, 13) },
                new Publication() { Author = new CustomUser() { Id = 2 }, CreatedOn = new DateTime(2016, 10, 12) },
                new Publication() { Author = new CustomUser() { Id = 3 }, CreatedOn = new DateTime(2016, 10, 15) }
            }.AsQueryable();
            mockedPublicationRepository.Setup(x => x.All).Returns(publications);

            var mockedFriendService = new Mock<IFriendService>();
            var friends = new List<int>() { 2, 3 };
            mockedFriendService.Setup(x => x.GetAllUserFriendsIds(It.IsAny<int>())).Returns(friends);
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
                mockedFriendService.Object,
                mockedUserService.Object,
                mockedUnitOfWork.Object,
                mockedPublicationFactory.Object,
                mockedDateTimeService.Object,
                mockedPublicationImageFactory.Object,
                mockedCommentService.Object);
            string userId = "user-xx-id";
            int skip = 1;
            int count = 4;

            // Act
            var result = publicationService.FriendsPublications(userId, skip, count);

            // Assert
            Assert.AreEqual(3, result.Count());
        }
    }
}
