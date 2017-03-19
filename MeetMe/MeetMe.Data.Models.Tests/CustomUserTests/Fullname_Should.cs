using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.CustomUserTests
{
    [TestFixture]
    public class Fullname_Should
    {
        [TestCase("John Smith")]
        [TestCase("Ivan Ivanov")]
        public void SetFullName_Correct(string fullName)
        {
            // Arrange
            var user = new CustomUser();

            // Act
            user.FullName = fullName;

            // Assert
            Assert.AreEqual(user.FullName, fullName);
        }
    }
}
