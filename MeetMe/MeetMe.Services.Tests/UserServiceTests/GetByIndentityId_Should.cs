using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Moq;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;

namespace MeetMe.Services.Tests.UserServiceTests
{
    [TestFixture]
    public class GetByIndentityId_Should
    {
        [Test]
        public void ReturnCorrectUser_WhenFound()
        {
            // Arrange
            string searchedId = "fifth";
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var user = new CustomUser() { AspIdentityUserId = searchedId };
            var users = new List<CustomUser>()
            {
                user,
                new CustomUser() { AspIdentityUserId = "first" },
                new CustomUser() { AspIdentityUserId = "third" }
            }.AsQueryable();
            mockedUserRepository.Setup(x => x.All).Returns(users);
            var userService = new UserService(mockedUserRepository.Object);

            // Act
            var result = userService.GetByIndentityId(searchedId);

            // Assert
            Assert.AreSame(result, user);
        }

        [Test]
        public void ReturnNull_WhenUserNotFound()
        {
            // Arrange
            string searchedId = "fifth";
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var users = new List<CustomUser>()
            {
                new CustomUser() { AspIdentityUserId = "first" },
                new CustomUser() { AspIdentityUserId = "third" }
            }.AsQueryable();
            mockedUserRepository.Setup(x => x.All).Returns(users);
            var userService = new UserService(mockedUserRepository.Object);

            // Act
            var result = userService.GetByIndentityId(searchedId);

            // Assert
            Assert.IsNull(result);
        }
    }
}
