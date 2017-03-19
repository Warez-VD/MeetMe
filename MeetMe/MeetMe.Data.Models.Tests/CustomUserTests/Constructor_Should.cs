using Moq;
using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.CustomUserTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnInstanceOfCustomUser_WithSetCorrectProperties()
        {
            // Arrange
            string firstName = "John";
            string lastName = "Smith";
            string fullname = $"{firstName} {lastName}";
            string userId = "123123-121";
            var logo = new Mock<ProfileImage>();

            // Act
            var user = new CustomUser(firstName, lastName, fullname, userId, logo.Object);

            // Assert
            Assert.AreEqual(user.FirstName, firstName);
            Assert.AreEqual(user.LastName, lastName);
            Assert.AreEqual(user.AspIdentityUserId, userId);
            Assert.AreEqual(user.ProfileImage, logo.Object);
            Assert.IsInstanceOf<CustomUser>(user);
        }
    }
}
