using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.StatisticTests
{
    [TestFixture]
    public class Id_Should
    {
        [TestCase(1)]
        [TestCase(550)]
        public void SetId_Correct(int id)
        {
            // Arrange
            var statistic = new Statistic();

            // Act
            statistic.Id = id;

            // Assert
            Assert.AreEqual(statistic.Id, id);
        }
    }
}
