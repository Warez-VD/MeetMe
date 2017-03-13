using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.CustomUserTests
{
    [TestFixture]
    public class Age_Should
    {
        [TestCase(21)]
        [TestCase(123)]
        public void SetAge_Correct(int age)
        {
            // Arrange
            var user = new CustomUser();

            // Act
            user.Age = age;

            // Assert
            Assert.AreEqual(user.Age, age);
        }
    }
}
