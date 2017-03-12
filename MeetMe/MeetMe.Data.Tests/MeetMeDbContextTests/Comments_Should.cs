using NUnit.Framework;
using Moq;
using MeetMe.Data.Models;
using System.Data.Entity;

namespace MeetMe.Data.Tests.MeetMeDbContextTests
{
    [TestFixture]
    public class Comments_Should
    {
        [Test]
        public void SetComments_Correct()
        {
            // Arrange
            var mockedDbSet = new Mock<IDbSet<Comment>>();
            var context = new MeetMeDbContext();

            // Act
            context.Comments = mockedDbSet.Object;

            // Assert
            Assert.AreSame(context.Comments, mockedDbSet.Object);
        }

        [Test]
        public void IsVirtual()
        {
            // Arrange
            var mockedDbSet = new Mock<IDbSet<CustomUser>>();
            var context = new MeetMeDbContext();

            // Act
            bool isVirtual = context.GetType().GetProperty("Comments").GetGetMethod().IsVirtual;

            // Assert
            Assert.IsTrue(isVirtual);
        }
    }
}
