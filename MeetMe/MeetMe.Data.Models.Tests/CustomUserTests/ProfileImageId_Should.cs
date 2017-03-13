using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.CustomUserTests
{
    [TestFixture]
    public class ProfileImageId_Should
    {
        [TestCase(21)]
        [TestCase(123)]
        public void SetProfileImageId_Correct(int profileImageId)
        {
            // Arrange
            var user = new CustomUser();

            // Act
            user.ProfileImageId = profileImageId;

            // Assert
            Assert.AreEqual(user.ProfileImageId, profileImageId);
        }
    }
}
