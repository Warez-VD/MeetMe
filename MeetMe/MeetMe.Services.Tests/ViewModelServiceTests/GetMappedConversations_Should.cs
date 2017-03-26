using System.Collections.Generic;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using MeetMe.Web.Models.Messages;
using Moq;
using NUnit.Framework;

namespace MeetMe.Services.Tests.ViewModelServiceTests
{
    [TestFixture]
    public class GetMappedConversations_Should
    {
        [Test]
        public void CallMapperService_UsersCountTimes()
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
            var conversations = new List<Conversation>()
            {
                new Conversation(),
                new Conversation(),
                new Conversation()
            };

            // Act
            viewModelService.GetMappedConversations(conversations);

            // Assert
            foreach (var conversation in conversations)
            {
                mockedMapperService.Verify(x => x.MapObject<ConversationViewModel>(conversation));
            }
        }
    }
}
