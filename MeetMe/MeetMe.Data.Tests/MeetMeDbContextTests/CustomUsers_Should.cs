using NUnit.Framework;
using Moq;
using System.Data.Entity;
using MeetMe.Data.Models;

namespace MeetMe.Data.Tests.MeetMeDbContextTests
{
    [TestFixture]
    public class CustomUsers_Should
    {
        [Test]
        public void SetCustomUsers_Correct()
        {
            // Arrange
            var mockedDbSet = new Mock<IDbSet<CustomUser>>();
            var context = new MeetMeDbContext();

            // Act
            context.CustomUsers = mockedDbSet.Object;

            // Assert
            Assert.AreSame(context.CustomUsers, mockedDbSet.Object);
        }

        [Test]
        public void IsVirtual()
        {
            // Arrange
            var mockedDbSet = new Mock<IDbSet<CustomUser>>();
            var context = new MeetMeDbContext();

            // Act
            bool isVirtual = context.GetType().GetProperty("CustomUsers").GetGetMethod().IsVirtual;

            // Assert
            Assert.IsTrue(isVirtual);
        }
    }
}
