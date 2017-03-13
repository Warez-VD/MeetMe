using System.Collections.Generic;
using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.CustomUserTests
{
    [TestFixture]
    public class Publications_Should
    {
        [Test]
        public void SetPublications_Correct()
        {
            // Arrange
            var publications = new HashSet<Publication>();
            var user = new CustomUser();

            // Act
            user.Publications = publications;

            // Assert
            Assert.AreSame(user.Publications, publications);
        }

        [Test]
        public void BeVirtual()
        {
            // Arrange
            var user = new CustomUser();

            // Act
            bool isVirtual = user.GetType().GetProperty("Publications").GetGetMethod().IsVirtual;

            // Assert
            Assert.IsTrue(isVirtual);
        }
    }
}
