using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.StatisticTests
{
    [TestFixture]
    public class MessagesCount_Should
    {
        [TestCase(21)]
        [TestCase(123)]
        public void SetMessagesCount_Correct(int messagesCount)
        {
            // Arrange
            var statistic = new Statistic();

            // Act
            statistic.MessagesCount = messagesCount;

            // Assert
            Assert.AreEqual(statistic.MessagesCount, messagesCount);
        }
    }
}
