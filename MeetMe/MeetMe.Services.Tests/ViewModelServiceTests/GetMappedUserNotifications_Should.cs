using System.Collections.Generic;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using MeetMe.Web.Models.Notifications;
using Moq;
using NUnit.Framework;

namespace MeetMe.Services.Tests.ViewModelServiceTests
{
    [TestFixture]
    public class GetMappedUserNotifications_Should
    {
        [Test]
        public void CallMapperService_MapObjectNotificationsCountTimes()
        {
            // Arrange
            var mockedMapperService = new Mock<IMapperService>();
            var mappedNotification = new NotificationUserViewModel();
            mockedMapperService.Setup(x => x.MapObject<NotificationUserViewModel>(It.IsAny<Notification>())).Returns(mappedNotification);
            var mockedImageService = new Mock<IImageService>();
            mockedImageService.Setup(x => x.ByteArrayToImageUrl(It.IsAny<byte[]>())).Returns("some-url");
            var mockedUserService = new Mock<IUserService>();
            var mockedFriendService = new Mock<IFriendService>();

            var viewModelService = new ViewModelService(
                mockedMapperService.Object,
                mockedImageService.Object,
                mockedUserService.Object,
                mockedFriendService.Object);
            var notifications = new List<Notification>()
            {
                new Notification() { User = new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 1, 2 } } } },
                new Notification() { User = new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 1, 2 } } } },
                new Notification() { User = new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 1, 2 } } } }
            };

            // Act
            viewModelService.GetMappedUserNotifications(notifications);

            // Assert
            mockedMapperService.Verify(x => x.MapObject<NotificationUserViewModel>(It.IsAny<Notification>()), Times.Exactly(notifications.Count));
        }

        [Test]
        public void CallImageService_ByteArrayToImageUrlNotificationsCountTimes()
        {
            // Arrange
            var mockedMapperService = new Mock<IMapperService>();
            var mappedNotification = new NotificationUserViewModel();
            mockedMapperService.Setup(x => x.MapObject<NotificationUserViewModel>(It.IsAny<Notification>())).Returns(mappedNotification);
            var mockedImageService = new Mock<IImageService>();
            mockedImageService.Setup(x => x.ByteArrayToImageUrl(It.IsAny<byte[]>())).Returns("some-url");
            var mockedUserService = new Mock<IUserService>();
            var mockedFriendService = new Mock<IFriendService>();

            var viewModelService = new ViewModelService(
                mockedMapperService.Object,
                mockedImageService.Object,
                mockedUserService.Object,
                mockedFriendService.Object);
            var notifications = new List<Notification>()
            {
                new Notification() { User = new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 1, 2 } } } },
                new Notification() { User = new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 1, 2 } } } },
                new Notification() { User = new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 1, 2 } } } }
            };

            // Act
            viewModelService.GetMappedUserNotifications(notifications);

            // Assert
            mockedImageService.Verify(x => x.ByteArrayToImageUrl(It.IsAny<byte[]>()), Times.Exactly(notifications.Count));
        }

        [Test]
        public void ReturnCorrectMappedNotifications()
        {
            // Arrange
            var mockedMapperService = new Mock<IMapperService>();
            var mappedNotification = new NotificationUserViewModel();
            mockedMapperService.Setup(x => x.MapObject<NotificationUserViewModel>(It.IsAny<Notification>())).Returns(mappedNotification);
            var mockedImageService = new Mock<IImageService>();
            mockedImageService.Setup(x => x.ByteArrayToImageUrl(It.IsAny<byte[]>())).Returns("some-url");
            var mockedUserService = new Mock<IUserService>();
            var mockedFriendService = new Mock<IFriendService>();

            var viewModelService = new ViewModelService(
                mockedMapperService.Object,
                mockedImageService.Object,
                mockedUserService.Object,
                mockedFriendService.Object);
            var notifications = new List<Notification>()
            {
                new Notification() { User = new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 1, 2 } } } },
                new Notification() { User = new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 1, 2 } } } },
                new Notification() { User = new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 1, 2 } } } }
            };
            var actual = new List<NotificationUserViewModel>() { mappedNotification, mappedNotification, mappedNotification };

            // Act
            var result = viewModelService.GetMappedUserNotifications(notifications);

            // Assert
            CollectionAssert.AreEqual(result, actual);
        }
    }
}
