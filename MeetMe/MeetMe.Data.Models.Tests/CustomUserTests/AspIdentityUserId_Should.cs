using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.CustomUserTests
{
    [TestFixture]
    public class AspIdentityUserId_Should
    {
        [TestCase("adsfadsf-1212")]
        [TestCase("xaxgg--vvfs")]
        public void SetAspIdentityUserId_Correct(string id)
        {
            // Arrange
            var user = new CustomUser();

            // Act
            user.AspIdentityUserId = id;

            // Assert
            Assert.AreEqual(user.AspIdentityUserId, id);
        }
    }
}
