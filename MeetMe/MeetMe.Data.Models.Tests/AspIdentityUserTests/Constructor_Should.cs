using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.AspIdentityUserTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnInstanceOfUser_WithSetCorrectProperties()
        {
            // Arrange
            string username = "someone@email.bg";
            string email = "someone@email.bg";

            // Act
            var user = new AspIdentityUser(username, email);

            // Assert
            Assert.AreEqual(user.UserName, username);
            Assert.AreEqual(user.Email, email);
            Assert.IsInstanceOf<AspIdentityUser>(user);
        }
    }
}
