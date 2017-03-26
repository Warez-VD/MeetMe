using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.ConversationTests
{
    [TestFixture]
    public class Id_Should
    {
        [TestCase(1)]
        [TestCase(550)]
        public void SetId_Correct(int id)
        {
            // Arrange
            var conversation = new Conversation();

            // Act
            conversation.Id = id;

            // Assert
            Assert.AreEqual(conversation.Id, id);
        }
    }
}
