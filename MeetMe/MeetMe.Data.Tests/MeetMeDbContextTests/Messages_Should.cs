using System.Data.Entity;
using MeetMe.Data.Models;
using Moq;
using NUnit.Framework;

namespace MeetMe.Data.Tests.MeetMeDbContextTests
{
    [TestFixture]
    public class Messages_Should
    {
        [Test]
        public void SetMessages_Correct()
        {
            // Arrange
            var mockedDbSet = new Mock<IDbSet<Message>>();
            var context = new MeetMeDbContext();

            // Act
            context.Messages = mockedDbSet.Object;

            // Assert
            Assert.AreSame(context.Messages, mockedDbSet.Object);
        }

        [Test]
        public void IsVirtual()
        {
            // Arrange
            var mockedDbSet = new Mock<IDbSet<Message>>();
            var context = new MeetMeDbContext();

            // Act
            bool isVirtual = context.GetType().GetProperty("Messages").GetGetMethod().IsVirtual;

            // Assert
            Assert.IsTrue(isVirtual);
        }
    }
}
