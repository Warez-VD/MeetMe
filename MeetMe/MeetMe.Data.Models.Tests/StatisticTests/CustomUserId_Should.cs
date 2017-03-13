using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.StatisticTests
{
    [TestFixture]
    public class CustomUserId_Should
    {
        [TestCase(21)]
        [TestCase(123)]
        public void SetCustomUserId_Correct(int id)
        {
            // Arrange
            var statistic = new Statistic();

            // Act
            statistic.CustomUserId = id;

            // Assert
            Assert.AreEqual(statistic.CustomUserId, id);
        }
    }
}
