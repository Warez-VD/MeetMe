using NUnit.Framework;
using Moq;
using MeetMe.Data.Models;
using System.Data.Entity;

namespace MeetMe.Data.Tests.MeetMeDbContextTests
{
    [TestFixture]
    public class Publications_Should
    {
        [Test]
        public void SetPublications_Correct()
        {
            // Arrange
            var mockedDbSet = new Mock<IDbSet<Publication>>();
            var context = new MeetMeDbContext();

            // Act
            context.Publications = mockedDbSet.Object;

            // Assert
            Assert.AreSame(context.Publications, mockedDbSet.Object);
        }

        [Test]
        public void IsVirtual()
        {
            // Arrange
            var mockedDbSet = new Mock<IDbSet<CustomUser>>();
            var context = new MeetMeDbContext();

            // Act
            bool isVirtual = context.GetType().GetProperty("Publications").GetGetMethod().IsVirtual;

            // Assert
            Assert.IsTrue(isVirtual);
        }
    }
}
