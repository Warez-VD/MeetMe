using System.Data.Entity;
using MeetMe.Data.Models;
using Moq;
using NUnit.Framework;

namespace MeetMe.Data.Tests.MeetMeDbContextTests
{
    [TestFixture]
    public class Conversations_Should
    {
        [Test]
        public void SetConversations_Correct()
        {
            // Arrange
            var mockedDbSet = new Mock<IDbSet<Conversation>>();
            var context = new MeetMeDbContext();

            // Act
            context.Conversations = mockedDbSet.Object;

            // Assert
            Assert.AreSame(context.Conversations, mockedDbSet.Object);
        }

        [Test]
        public void IsVirtual()
        {
            // Arrange
            var mockedDbSet = new Mock<IDbSet<Conversation>>();
            var context = new MeetMeDbContext();

            // Act
            bool isVirtual = context.GetType().GetProperty("Conversations").GetGetMethod().IsVirtual;

            // Assert
            Assert.IsTrue(isVirtual);
        }
    }
}
