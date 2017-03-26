using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.MessageTests
{
    [TestFixture]
    public class Id_Should
    {
        [TestCase(1)]
        [TestCase(550)]
        public void SetId_Correct(int id)
        {
            // Arrange
            var message = new Message();

            // Act
            message.Id = id;

            // Assert
            Assert.AreEqual(message.Id, id);
        }
    }
}
