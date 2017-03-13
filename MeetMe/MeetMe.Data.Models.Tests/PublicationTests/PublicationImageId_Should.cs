using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.PublicationTests
{
    [TestFixture]
    public class PublicationImageId_Should
    {
        [TestCase(1)]
        [TestCase(550)]
        public void SetPublicationImageId_Correct(int id)
        {
            // Arrange
            var publication = new Publication();

            // Act
            publication.PublicationImageId = id;

            // Assert
            Assert.AreEqual(publication.PublicationImageId, id);
        }
    }
}
