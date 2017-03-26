using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.ConversationTests
{
    [TestFixture]
    public class SecondUserId_Should
    {
        [TestCase("some-id")]
        [TestCase("other-id")]
        public void SetSecondUserId_Correct(string id)
        {
            // Arrange
            var conversation = new Conversation();

            // Act
            conversation.SecondUserId = id;

            // Assert
            Assert.AreEqual(conversation.SecondUserId, id);
        }
    }
}
