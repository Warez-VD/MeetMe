using System;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;

namespace MeetMe.Data.Models.Tests.CustomUserTests
{
    [TestFixture]
    public class City_Should
    {
        [TestCase("Sofia")]
        [TestCase("Burgas")]
        public void SetCity_Correct(string city)
        {
            // Arrange
            var user = new CustomUser();

            // Act
            user.City = city;

            // Assert
            Assert.AreEqual(user.City, city);
        }

        [Test]
        public void HaveMaxLength_Attribute()
        {
            // Arrange
            var user = new CustomUser();
            var property = user.GetType().GetProperty("City");

            // Act
            bool isDefined = Attribute.IsDefined(property, typeof(MaxLengthAttribute));

            // Assert
            Assert.IsTrue(isDefined);
        }
    }
}
