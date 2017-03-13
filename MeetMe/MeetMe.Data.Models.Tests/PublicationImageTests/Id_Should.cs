using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.PublicationImageTests
{
    [TestFixture]
    public class Id_Should
    {
        [TestCase(1)]
        [TestCase(550)]
        public void SetId_Correct(int id)
        {
            // Arrange
            var image = new PublicationImage();

            // Act
            image.Id = id;

            // Assert
            Assert.AreEqual(image.Id, id);
        }
    }
}
