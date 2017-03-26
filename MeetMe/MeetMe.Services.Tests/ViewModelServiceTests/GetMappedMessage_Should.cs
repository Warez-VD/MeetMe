using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using MeetMe.Web.Models.Messages;
using Moq;
using NUnit.Framework;

namespace MeetMe.Services.Tests.ViewModelServiceTests
{
    [TestFixture]
    public class GetMappedMessage_Should
    {
        [Test]
        public void CallMapperService_MapObjectOnce()
        {
            // Arrange
            var mockedMapperService = new Mock<IMapperService>();
            var mappedMessage = new MessageViewModel();
            mockedMapperService.Setup(x => x.MapObject<MessageViewModel>(It.IsAny<Message>())).Returns(mappedMessage);
            var mockedImageService = new Mock<IImageService>();
            mockedImageService.Setup(x => x.ByteArrayToImageUrl(It.IsAny<byte[]>())).Returns("some-url");
            var mockedUserService = new Mock<IUserService>();
            var mockedFriendService = new Mock<IFriendService>();

            var viewModelService = new ViewModelService(
                mockedMapperService.Object,
                mockedImageService.Object,
                mockedUserService.Object,
                mockedFriendService.Object);

            var message = new Message()
            {
                User = new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 1, 2 } } }
            };

            // Act
            viewModelService.GetMappedMessage(message);

            // Assert
            mockedMapperService.Verify(x => x.MapObject<MessageViewModel>(message), Times.Once);
        }

        [Test]
        public void CallImageService_ByteArrayToImageUrlOnce()
        {
            // Arrange
            var mockedMapperService = new Mock<IMapperService>();
            var mappedMessage = new MessageViewModel();
            mockedMapperService.Setup(x => x.MapObject<MessageViewModel>(It.IsAny<Message>())).Returns(mappedMessage);
            var mockedImageService = new Mock<IImageService>();
            mockedImageService.Setup(x => x.ByteArrayToImageUrl(It.IsAny<byte[]>())).Returns("some-url");
            var mockedUserService = new Mock<IUserService>();
            var mockedFriendService = new Mock<IFriendService>();

            var viewModelService = new ViewModelService(
                mockedMapperService.Object,
                mockedImageService.Object,
                mockedUserService.Object,
                mockedFriendService.Object);

            var message = new Message()
            {
                User = new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 1, 2 } } }
            };

            // Act
            viewModelService.GetMappedMessage(message);

            // Assert
            mockedImageService.Verify(x => x.ByteArrayToImageUrl(message.User.ProfileImage.Content), Times.Once);
        }
    }
}
