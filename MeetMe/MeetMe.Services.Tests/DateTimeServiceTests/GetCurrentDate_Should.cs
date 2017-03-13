using System;
using NUnit.Framework;

namespace MeetMe.Services.Tests.DateTimeServiceTests
{
    [TestFixture]
    public class GetCurrentDate_Should
    {
        [Test]
        public void ReturnCurrentDateTime()
        {
            // Arrange
            var dateTimeService = new DateTimeService();

            // Act
            var result = dateTimeService.GetCurrentDate();

            // Assert
            Assert.AreEqual(result.Day, DateTime.Now.Day);
            Assert.AreEqual(result.Month, DateTime.Now.Month);
            Assert.AreEqual(result.Year, DateTime.Now.Year);
            Assert.AreEqual(result.Hour, DateTime.Now.Hour);
            Assert.AreEqual(result.Minute, DateTime.Now.Minute);
            Assert.IsInstanceOf<DateTime>(result);
        }
    }
}
