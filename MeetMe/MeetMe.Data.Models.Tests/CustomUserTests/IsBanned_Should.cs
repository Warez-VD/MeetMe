using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.CustomUserTests
{
    [TestFixture]
    public class IsBanned_Should
    {
        [TestCase(true)]
        [TestCase(false)]
        public void SetIsBanned_Correct(bool isBanned)
        {
            // Arrange
            var user = new CustomUser();

            // Act
            user.IsBanned = isBanned;

            // Assert
            Assert.AreEqual(user.IsBanned, isBanned);
        }
    }
}
