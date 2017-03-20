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
    public class GetMappedPublications_Should
    {
        [Test]
        public void CallImageService_ByteArrayToImageUrl()
        {
            // Arrange
            var mockedMapperService = new Mock<IMapperService>();
            var mappedPublication = new PublicationViewModel();
            mockedMapperService.Setup(x => x.MapObject<PublicationViewModel>(It.IsAny<Publication>())).Returns(mappedPublication);
            var mockedImageService = new Mock<IImageService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedFriendService = new Mock<IFriendService>();
            
            var viewModelService = new ViewModelService(
                mockedMapperService.Object,
                mockedImageService.Object,
                mockedUserService.Object,
                mockedFriendService.Object);
            var publications = new List<Publication>()
            {
                new Publication() { Author = new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 1, 2 } } }, Image = new PublicationImage() { Content = new byte[] { 1, 2 } } },
                new Publication() { Author = new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 1, 2 } } }, Image = new PublicationImage() { Content = new byte[] { 1, 2 } } },
                new Publication() { Author = new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 1, 2 } } }, Image = new PublicationImage() { Content = new byte[] { 1, 2 } } }
            };

            // Act
            viewModelService.GetMappedPublications(publications);

            // Assert
            mockedImageService.Verify(x => x.ByteArrayToImageUrl(It.IsAny<byte[]>()), Times.Exactly(publications.Count * 2));
        }

        [Test]
        public void CallMapperService_PublicationsCountTimes()
        {
            // Arrange
            var mockedMapperService = new Mock<IMapperService>();
            var mappedPublication = new PublicationViewModel();
            mockedMapperService.Setup(x => x.MapObject<PublicationViewModel>(It.IsAny<Publication>())).Returns(mappedPublication);
            var mockedImageService = new Mock<IImageService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedFriendService = new Mock<IFriendService>();

            var viewModelService = new ViewModelService(
                mockedMapperService.Object,
                mockedImageService.Object,
                mockedUserService.Object,
                mockedFriendService.Object);
            var publications = new List<Publication>()
            {
                new Publication() { Author = new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 1, 2 } } }, Image = new PublicationImage() { Content = new byte[] { 1, 2 } } },
                new Publication() { Author = new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 1, 2 } } }, Image = new PublicationImage() { Content = new byte[] { 1, 2 } } },
                new Publication() { Author = new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 1, 2 } } }, Image = new PublicationImage() { Content = new byte[] { 1, 2 } } }
            };

            // Act
            viewModelService.GetMappedPublications(publications);

            // Assert
            mockedMapperService.Verify(x => x.MapObject<PublicationViewModel>(It.IsAny<Publication>()), Times.Exactly(publications.Count));
        }

        [Test]
        public void ReturnMappedPublicationsInCorrectType()
        {
            // Arrange
            var mockedMapperService = new Mock<IMapperService>();
            var mappedPublication = new PublicationViewModel();
            mockedMapperService.Setup(x => x.MapObject<PublicationViewModel>(It.IsAny<Publication>())).Returns(mappedPublication);
            var mockedImageService = new Mock<IImageService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedFriendService = new Mock<IFriendService>();

            var viewModelService = new ViewModelService(
                mockedMapperService.Object,
                mockedImageService.Object,
                mockedUserService.Object,
                mockedFriendService.Object);
            var publications = new List<Publication>()
            {
                new Publication() { Author = new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 1, 2 } } }, Image = new PublicationImage() { Content = new byte[] { 1, 2 } } },
                new Publication() { Author = new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 1, 2 } } }, Image = new PublicationImage() { Content = new byte[] { 1, 2 } } },
                new Publication() { Author = new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 1, 2 } } }, Image = new PublicationImage() { Content = new byte[] { 1, 2 } } }
            };

            // Act
            var result = viewModelService.GetMappedPublications(publications);

            // Assert
            Assert.That(result.All(x => x.GetType().Name == "PublicationViewModel"));
        }

        [Test]
        public void ReturnCoorectCountMappedPublications()
        {
            // Arrange
            var mockedMapperService = new Mock<IMapperService>();
            var mappedPublication = new PublicationViewModel();
            mockedMapperService.Setup(x => x.MapObject<PublicationViewModel>(It.IsAny<Publication>())).Returns(mappedPublication);
            var mockedImageService = new Mock<IImageService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedFriendService = new Mock<IFriendService>();

            var viewModelService = new ViewModelService(
                mockedMapperService.Object,
                mockedImageService.Object,
                mockedUserService.Object,
                mockedFriendService.Object);
            var publications = new List<Publication>()
            {
                new Publication() { Author = new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 1, 2 } } }, Image = new PublicationImage() { Content = new byte[] { 1, 2 } } },
                new Publication() { Author = new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 1, 2 } } }, Image = new PublicationImage() { Content = new byte[] { 1, 2 } } },
                new Publication() { Author = new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 1, 2 } } }, Image = new PublicationImage() { Content = new byte[] { 1, 2 } } }
            };

            // Act
            var result = viewModelService.GetMappedPublications(publications);

            // Assert
            Assert.AreEqual(result.Count(), 3);
        }
    }
}
