using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.MessageTests
{
    [TestFixture]
    public class CustomUserId_Should
    {
        [TestCase(1)]
        [TestCase(550)]
        public void SetCustomUserId_Correct(int id)
        {
            // Arrange
            var message = new Message();

            // Act
            message.CustomUserId = id;

            // Assert
            Assert.AreEqual(message.CustomUserId, id);
        }
    }
}
