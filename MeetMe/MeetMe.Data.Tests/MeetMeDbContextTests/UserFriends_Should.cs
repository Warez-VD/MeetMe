using System.Data.Entity;
using MeetMe.Data.Models;
using Moq;
using NUnit.Framework;

namespace MeetMe.Data.Tests.MeetMeDbContextTests
{
    [TestFixture]
    public class UserFriends_Should
    {
        [Test]
        public void SetNotifications_Correct()
        {
            // Arrange
            var mockedDbSet = new Mock<IDbSet<UserFriend>>();
            var context = new MeetMeDbContext();

            // Act
            context.UserFriends = mockedDbSet.Object;

            // Assert
            Assert.AreSame(context.UserFriends, mockedDbSet.Object);
        }

        [Test]
        public void IsVirtual()
        {
            // Arrange
            var mockedDbSet = new Mock<IDbSet<UserFriend>>();
            var context = new MeetMeDbContext();

            // Act
            bool isVirtual = context.GetType().GetProperty("UserFriends").GetGetMethod().IsVirtual;

            // Assert
            Assert.IsTrue(isVirtual);
        }
    }
}
