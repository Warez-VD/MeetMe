using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.PublicationTests
{
    [TestFixture]
    public class Id_Should
    {
        [TestCase(1)]
        [TestCase(550)]
        public void SetId_Correct(int id)
        {
            // Arrange
            var publication = new Publication();

            // Act
            publication.Id = id;

            // Assert
            Assert.AreEqual(publication.Id, id);
        }
    }
}
