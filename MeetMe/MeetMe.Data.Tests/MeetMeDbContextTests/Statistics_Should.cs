using System.Data.Entity;
using MeetMe.Data.Models;
using Moq;
using NUnit.Framework;

namespace MeetMe.Data.Tests.MeetMeDbContextTests
{
    [TestFixture]
    public class Statistics_Should
    {
        [Test]
        public void SetStatistics_Correct()
        {
            // Arrange
            var mockedDbSet = new Mock<IDbSet<Statistic>>();
            var context = new MeetMeDbContext();

            // Act
            context.Statistics = mockedDbSet.Object;

            // Assert
            Assert.AreSame(context.Statistics, mockedDbSet.Object);
        }

        [Test]
        public void IsVirtual()
        {
            // Arrange
            var mockedDbSet = new Mock<IDbSet<CustomUser>>();
            var context = new MeetMeDbContext();

            // Act
            bool isVirtual = context.GetType().GetProperty("Statistics").GetGetMethod().IsVirtual;

            // Assert
            Assert.IsTrue(isVirtual);
        }
    }
}
