using System;
using MeetMe.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace MeetMe.Services.Tests.ViewModelServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhen_MapperServiceIsNull()
        {
            // Arrange
            var mockedImageService = new Mock<IImageService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedFriendService = new Mock<IFriendService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new ViewModelService(
                null,
                mockedImageService.Object,
                mockedUserService.Object,
                mockedFriendService.Object));

            // Assert
            Assert.That(ex.Message.Contains("MapperService"));
        }

        [Test]
        public void ThrowsWhen_ImageServiceIsNull()
        {
            // Arrange
            var mockedMapperService = new Mock<IMapperService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedFriendService = new Mock<IFriendService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new ViewModelService(
                mockedMapperService.Object,
                null,
                mockedUserService.Object,
                mockedFriendService.Object));

            // Assert
            Assert.That(ex.Message.Contains("ImageService"));
        }

        [Test]
        public void ThrowsWhen_UserServiceIsNull()
        {
            // Arrange
            var mockedMapperService = new Mock<IMapperService>();
            var mockedImageService = new Mock<IImageService>();
            var mockedFriendService = new Mock<IFriendService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new ViewModelService(
                mockedMapperService.Object,
                mockedImageService.Object,
                null,
                mockedFriendService.Object));

            // Assert
            Assert.That(ex.Message.Contains("UserService"));
        }

        [Test]
        public void ThrowsWhen_FriendServiceIsNull()
        {
            // Arrange
            var mockedMapperService = new Mock<IMapperService>();
            var mockedImageService = new Mock<IImageService>();
            var mockedUserService = new Mock<IUserService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new ViewModelService(
                mockedMapperService.Object,
                mockedImageService.Object,
                mockedUserService.Object,
                null));

            // Assert
            Assert.That(ex.Message.Contains("FriendService"));
        }

        [Test]
        public void ReturnInstanceOfViewModelService_Correct()
        {
            // Arrange
            var mockedMapperService = new Mock<IMapperService>();
            var mockedImageService = new Mock<IImageService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedFriendService = new Mock<IFriendService>();

            // Act
            var viewModelService = new ViewModelService(
                mockedMapperService.Object,
                mockedImageService.Object,
                mockedUserService.Object,
                mockedFriendService.Object);

            // Assert
            Assert.IsNotNull(viewModelService);
            Assert.IsInstanceOf<ViewModelService>(viewModelService);
        }
    }
}
