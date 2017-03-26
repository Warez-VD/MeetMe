using Moq;
using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.MessageTests
{
    [TestFixture]
    public class User_Should
    {
        [Test]
        public void SetUser_Correct()
        {
            // Arrange
            var user = new Mock<CustomUser>();
            var message = new Message();

            // Act
            message.User = user.Object;

            // Assert
            Assert.AreSame(message.User, user.Object);
        }

        [Test]
        public void BeVirtual()
        {
            // Arrange
            var message = new Message();

            // Act
            bool isVirtual = message.GetType().GetProperty("User").GetGetMethod().IsVirtual;

            // Assert
            Assert.IsTrue(isVirtual);
        }
    }
}
