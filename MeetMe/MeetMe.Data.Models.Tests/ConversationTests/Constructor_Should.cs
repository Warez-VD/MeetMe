using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.ConversationTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnInstanceOfConversation_WithSetCorrectProperties()
        {
            // Arrange
            string firstUserId = "first-user-id";
            string secondUserId = "second-user-id";

            // Act
            var conversation = new Conversation(firstUserId, secondUserId);

            // Assert
            Assert.AreEqual(conversation.FirstUserId, firstUserId);
            Assert.AreEqual(conversation.SecondUserId, secondUserId);
            Assert.IsInstanceOf<Conversation>(conversation);
        }
    }
}
