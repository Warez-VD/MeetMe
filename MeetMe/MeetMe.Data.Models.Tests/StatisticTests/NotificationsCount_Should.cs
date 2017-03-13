using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.StatisticTests
{
    [TestFixture]
    public class NotificationsCount_Should
    {
        [TestCase(21)]
        [TestCase(123)]
        public void SetNotificationsCount_Correct(int notificationsCount)
        {
            // Arrange
            var statistic = new Statistic();

            // Act
            statistic.NotificationsCount = notificationsCount;

            // Assert
            Assert.AreEqual(statistic.NotificationsCount, notificationsCount);
        }
    }
}
