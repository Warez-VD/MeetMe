using System;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;

namespace MeetMe.Data.Models.Tests.CustomUserTests
{
    [TestFixture]
    public class School_Should
    {
        [TestCase("FirstSchool")]
        [TestCase("SecondSchool")]
        public void SetSchool_Correct(string school)
        {
            // Arrange
            var user = new CustomUser();

            // Act
            user.School = school;

            // Assert
            Assert.AreEqual(user.School, school);
        }

        [Test]
        public void HaveMaxLength_Attribute()
        {
            // Arrange
            var user = new CustomUser();
            var property = user.GetType().GetProperty("School");

            // Act
            bool isDefined = Attribute.IsDefined(property, typeof(MaxLengthAttribute));

            // Assert
            Assert.IsTrue(isDefined);
        }
    }
}
