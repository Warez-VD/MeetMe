using System.Collections.Generic;
using System.Linq;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using MeetMe.Web.Models.Messages;
using Moq;
using NUnit.Framework;

namespace MeetMe.Services.Tests.ViewModelServiceTests
{
    [TestFixture]
    public class GetMappedConversation_Should
    {
        [Test]
        public void CallMapperService_MapObjectOnce()
        {
            // Arrange
            var mockedMapperService = new Mock<IMapperService>();
            var mappedConversation = new ConversationViewModel();
            mockedMapperService.Setup(x => x.MapObject<ConversationViewModel>(It.IsAny<Conversation>())).Returns(mappedConversation);
            var mockedImageService = new Mock<IImageService>();
            mockedImageService.Setup(x => x.ByteArrayToImageUrl(It.IsAny<byte[]>())).Returns("some-url");
            var mockedUserService = new Mock<IUserService>();
            var mockedFriendService = new Mock<IFriendService>();

            var viewModelService = new ViewModelService(
                mockedMapperService.Object,
                mockedImageService.Object,
                mockedUserService.Object,
                mockedFriendService.Object);

            var conversation = new Conversation();

            // Act
            viewModelService.GetMappedConversation(conversation);

            // Assert
            mockedMapperService.Verify(x => x.MapObject<ConversationViewModel>(conversation), Times.Once);
        }

        [Test]
        public void CallImageService_ByteArrayToImageUrlConvesationMessageCountTimes()
        {
            // Arrange
            var mockedMapperService = new Mock<IMapperService>();
            var mappedConversation = new ConversationViewModel();
            mappedConversation.Messages = new List<MessageViewModel>()
            {
                new MessageViewModel(),
                new MessageViewModel(),
                new MessageViewModel()
            };
            mockedMapperService.Setup(x => x.MapObject<ConversationViewModel>(It.IsAny<Conversation>())).Returns(mappedConversation);
            var mockedImageService = new Mock<IImageService>();
            mockedImageService.Setup(x => x.ByteArrayToImageUrl(It.IsAny<byte[]>())).Returns("some-url");
            var mockedUserService = new Mock<IUserService>();
            var mockedFriendService = new Mock<IFriendService>();

            var viewModelService = new ViewModelService(
                mockedMapperService.Object,
                mockedImageService.Object,
                mockedUserService.Object,
                mockedFriendService.Object);

            var conversation = new Conversation();
            conversation.Messages = new List<Message>()
            {
                new Message() { User = new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 1, 2 } } } },
                new Message() { User = new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 2, 3 } } } },
                new Message() { User = new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 3, 4 } } } },
            };
            var messages = conversation.Messages.ToList();

            // Act
            viewModelService.GetMappedConversation(conversation);

            // Assert
            for (int i = 0; i < messages.Count; i++)
            {
                mockedImageService.Verify(x => x.ByteArrayToImageUrl(messages[i].User.ProfileImage.Content));
            }
        }
    }
}
