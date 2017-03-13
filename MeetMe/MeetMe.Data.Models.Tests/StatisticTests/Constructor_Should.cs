using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.StatisticTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnInstanceOfStatistic_WithSetCorrectProperties()
        {
            // Arrange
            int notificationCount = 12;
            int messageCount = 14;
            int userId = 3;

            // Act
            var statistic = new Statistic(notificationCount, messageCount, userId);

            // Assert
            Assert.AreEqual(statistic.NotificationsCount, notificationCount);
            Assert.AreEqual(statistic.MessagesCount, messageCount);
            Assert.AreEqual(statistic.CustomUserId, userId);
            Assert.IsInstanceOf<Statistic>(statistic);
        }
    }
}
