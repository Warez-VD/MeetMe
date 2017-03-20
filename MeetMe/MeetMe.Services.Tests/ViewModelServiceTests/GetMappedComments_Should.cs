using System;
using System.Collections.Generic;
using System.Linq;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using MeetMe.Web.Models.Publications;
using Moq;
using NUnit.Framework;

namespace MeetMe.Services.Tests.ViewModelServiceTests
{
    [TestFixture]
    public class GetMappedComments_Should
    {
        [Test]
        public void CallMapperService_MapObjectOnce()
        {
            // Arrange
            var mockedMapperService = new Mock<IMapperService>();
            var mappedPublication = new PublicationViewModel();
            mappedPublication.Comments = new List<CommentViewModel>();
            mockedMapperService.Setup(x => x.MapObject<PublicationViewModel>(It.IsAny<Publication>())).Returns(mappedPublication);
            var mockedImageService = new Mock<IImageService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedFriendService = new Mock<IFriendService>();

            var viewModelService = new ViewModelService(
                mockedMapperService.Object,
                mockedImageService.Object,
                mockedUserService.Object,
                mockedFriendService.Object);
            var publication = new Publication();

            // Act
            viewModelService.GetMappedComments(publication);

            // Assert
            mockedMapperService.Verify(x => x.MapObject<PublicationViewModel>(It.Is<Publication>(p => p == publication)), Times.Once);
        }

        [Test]
        public void CallImageService_ByteArrayToImageUrlCommentsCountTimes()
        {
            // Arrange
            var mockedMapperService = new Mock<IMapperService>();
            var mappedPublication = new PublicationViewModel();
            mappedPublication.Comments = new List<CommentViewModel>()
            {
                new CommentViewModel(),
                new CommentViewModel(),
                new CommentViewModel()
            };
            mockedMapperService.Setup(x => x.MapObject<PublicationViewModel>(It.IsAny<Publication>())).Returns(mappedPublication);
            var mockedImageService = new Mock<IImageService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedFriendService = new Mock<IFriendService>();

            var viewModelService = new ViewModelService(
                mockedMapperService.Object,
                mockedImageService.Object,
                mockedUserService.Object,
                mockedFriendService.Object);
            var publication = new Publication();

            // Act
            viewModelService.GetMappedComments(publication);

            // Assert
            mockedImageService.Verify(x => x.ByteArrayToImageUrl(It.IsAny<byte[]>()), Times.Exactly(mappedPublication.Comments.Count()));
        }

        [Test]
        public void ReturnCommentOrderedByDateDescending()
        {
            // Arrange
            var mockedMapperService = new Mock<IMapperService>();
            var mappedPublication = new PublicationViewModel();
            mappedPublication.Comments = new List<CommentViewModel>()
            {
                new CommentViewModel() { CreatedOn = new DateTime(2017, 3, 20) },
                new CommentViewModel() { CreatedOn = new DateTime(2017, 3, 21) },
                new CommentViewModel() { CreatedOn = new DateTime(2017, 3, 11) }
            };
            mockedMapperService.Setup(x => x.MapObject<PublicationViewModel>(It.IsAny<Publication>())).Returns(mappedPublication);
            var mockedImageService = new Mock<IImageService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedFriendService = new Mock<IFriendService>();

            var viewModelService = new ViewModelService(
                mockedMapperService.Object,
                mockedImageService.Object,
                mockedUserService.Object,
                mockedFriendService.Object);
            var publication = new Publication();
            var actual = mappedPublication.Comments.OrderByDescending(x => x.CreatedOn);

            // Act
            var result = viewModelService.GetMappedComments(publication);

            // Assert
            CollectionAssert.AreEqual(result, actual);
        }
    }
}
