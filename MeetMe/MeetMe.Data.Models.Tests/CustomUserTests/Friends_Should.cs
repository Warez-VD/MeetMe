using System.Collections.Generic;
using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.CustomUserTests
{
    [TestFixture]
    public class Friends_Should
    {
        [Test]
        public void SetFriends_Correct()
        {
            // Arrange
            var friends = new HashSet<CustomUser>();
            var user = new CustomUser();

            // Act
            user.Friends = friends;

            // Assert
            Assert.AreSame(user.Friends, friends);
        }

        [Test]
        public void BeVirtual()
        {
            // Arrange
            var user = new CustomUser();

            // Act
            bool isVirtual = user.GetType().GetProperty("Friends").GetGetMethod().IsVirtual;

            // Assert
            Assert.IsTrue(isVirtual);
        }
    }
}
