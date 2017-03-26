using System.Collections.Generic;
using MeetMe.Services.Contracts;
using MeetMe.Web.Controllers;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace MeetMe.Web.Tests.Controllers.UsersControllerTests
{
    [TestFixture]
    public class Usernames_Should
    {
        [Test]
        public void CallUserService_GetUsernamesOnce()
        {
            // Arrange
            var mockedUserService = new Mock<IUserService>();
            
            var usersController = new UsersController(mockedUserService.Object);

            // Act
            usersController.Usernames();

            // Assert
            mockedUserService.Verify(x => x.GetUsernames(), Times.Once);
        }

        [Test]
        public void ReturnResultAsJson()
        {
            // Arrange
            var mockedUserService = new Mock<IUserService>();
            var usernames = new List<string>() { "first", "second" };
            mockedUserService.Setup(x => x.GetUsernames()).Returns(usernames);

            var usersController = new UsersController(mockedUserService.Object);

            // Act & Assert
            usersController.WithCallTo(x => x.Usernames())
                .ShouldReturnJson();
        }
    }
}
