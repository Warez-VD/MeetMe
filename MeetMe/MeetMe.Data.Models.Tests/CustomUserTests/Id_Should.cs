using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.CustomUserTests
{
    [TestFixture]
    public class Id_Should
    {
        [TestCase(1)]
        [TestCase(550)]
        public void SetId_Correct(int id)
        {
            // Arrange
            var user = new CustomUser();

            // Act
            user.Id = id;

            // Assert
            Assert.AreEqual(user.Id, id);
        }
    }
}
