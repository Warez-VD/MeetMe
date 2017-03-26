using System.Collections.Generic;
using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.ConversationTests
{
    [TestFixture]
    public class Messages_Should
    {
        [Test]
        public void SetMessages_Correct()
        {
            // Arrange
            var messages = new HashSet<Message>();
            var conversation = new Conversation();

            // Act
            conversation.Messages = messages;

            // Assert
            Assert.AreSame(conversation.Messages, messages);
        }

        [Test]
        public void BeVirtual()
        {
            // Arrange
            var conversation = new Conversation();

            // Act
            bool isVirtual = conversation.GetType().GetProperty("Messages").GetGetMethod().IsVirtual;

            // Assert
            Assert.IsTrue(isVirtual);
        }
    }
}
