using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.ConversationTests
{
    [TestFixture]
    public class FirstUserId_Should
    {
        [TestCase("some-id")]
        [TestCase("other-id")]
        public void SetFirstUserId_Correct(string id)
        {
            // Arrange
            var conversation = new Conversation();

            // Act
            conversation.FirstUserId = id;

            // Assert
            Assert.AreEqual(conversation.FirstUserId, id);
        }
    }
}
