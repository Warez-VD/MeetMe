using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.PublicationTests
{
    [TestFixture]
    public class CustomUserId_Should
    {
        [TestCase(1)]
        [TestCase(550)]
        public void SetCustomUserId_Correct(int id)
        {
            // Arrange
            var publication = new Publication();

            // Act
            publication.CustomUserId = id;

            // Assert
            Assert.AreEqual(publication.CustomUserId, id);
        }
    }
}
