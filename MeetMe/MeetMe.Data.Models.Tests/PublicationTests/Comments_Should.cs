using System.Collections.Generic;
using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.PublicationTests
{
    [TestFixture]
    public class Comments_Should
    {
        [Test]
        public void SetComments_Correct()
        {
            // Arrange
            var comments = new HashSet<Comment>();
            var publication = new Publication();

            // Act
            publication.Comments = comments;

            // Assert
            Assert.AreSame(publication.Comments, comments);
        }

        [Test]
        public void BeVirtual()
        {
            // Arrange
            var publication = new Publication();

            // Act
            bool isVirtual = publication.GetType().GetProperty("Comments").GetGetMethod().IsVirtual;

            // Assert
            Assert.IsTrue(isVirtual);
        }
    }
}
