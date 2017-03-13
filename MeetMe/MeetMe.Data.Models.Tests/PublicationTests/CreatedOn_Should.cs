using System;
using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.PublicationTests
{
    [TestFixture]
    public class CreatedOn_Should
    {
        [Test]
        public void SetCreatedOn_Correct()
        {
            // Arrange
            DateTime createdOn = new DateTime(1994, 11, 12);
            var publication = new Publication();

            // Act
            publication.CreatedOn = createdOn;

            // Assert
            Assert.AreEqual(publication.CreatedOn, createdOn);
        }
    }
}
