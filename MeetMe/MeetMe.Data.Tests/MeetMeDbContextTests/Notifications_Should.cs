using System.Data.Entity;
using NUnit.Framework;
using Moq;
using MeetMe.Data.Models;

namespace MeetMe.Data.Tests.MeetMeDbContextTests
{
    [TestFixture]
    public class Notifications_Should
    {
        [Test]
        public void SetNotifications_Correct()
        {
            // Arrange
            var mockedDbSet = new Mock<IDbSet<Notification>>();
            var context = new MeetMeDbContext();

            // Act
            context.Notifications = mockedDbSet.Object;

            // Assert
            Assert.AreSame(context.Notifications, mockedDbSet.Object);
        }

        [Test]
        public void IsVirtual()
        {
            // Arrange
            var mockedDbSet = new Mock<IDbSet<Notification>>();
            var context = new MeetMeDbContext();

            // Act
            bool isVirtual = context.GetType().GetProperty("Notifications").GetGetMethod().IsVirtual;

            // Assert
            Assert.IsTrue(isVirtual);
        }
    }
}
