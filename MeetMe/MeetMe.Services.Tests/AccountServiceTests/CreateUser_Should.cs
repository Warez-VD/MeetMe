using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace MeetMe.Services.Tests.AccountServiceTests
{
    [TestFixture]
    public class CreateUser_Should
    {
        [Test]
        public void CallAspIdentityUserFactory_Once()
        {
            // Arrange
            var mockedAspIdentityUserFactory = new Mock<IAspIdentityUserFactory>();
            var mockedUserFactory = new Mock<ICustomUserFactory>();
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedImageService = new Mock<IImageService>();
            var mockedProfileLogoFactory = new Mock<IProfileLogoFactory>();
            
            var accountService = new AccountService(
                mockedAspIdentityUserFactory.Object,
                mockedUserFactory.Object,
                mockedUserRepository.Object,
                mockedUnitOfWork.Object,
                mockedImageService.Object,
                mockedProfileLogoFactory.Object);

            string username = "somename";
            string email = "some@email.bg";

            // Act
            accountService.CreateUser(username, email);

            // Assert
            mockedAspIdentityUserFactory
                .Verify(
                    x =>
                        x.CreateAspIdentityUser(
                            It.Is<string>(u => u == username),
                            It.Is<string>(e => e == email)),
                            Times.Once);
        }

        [Test]
        public void ReturnCorrectUser()
        {
            // Arrange
            string username = "somename";
            string email = "some@email.bg";
            var mockedAspIdentityUserFactory = new Mock<IAspIdentityUserFactory>();
            var user = new AspIdentityUser(username, email);
            mockedAspIdentityUserFactory.Setup(x => x.CreateAspIdentityUser(It.IsAny<string>(), It.IsAny<string>())).Returns(user);
            var mockedUserFactory = new Mock<ICustomUserFactory>();
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedImageService = new Mock<IImageService>();
            var mockedProfileLogoFactory = new Mock<IProfileLogoFactory>();

            var accountService = new AccountService(
                mockedAspIdentityUserFactory.Object,
                mockedUserFactory.Object,
                mockedUserRepository.Object,
                mockedUnitOfWork.Object,
                mockedImageService.Object,
                mockedProfileLogoFactory.Object);

            // Act
            var result = accountService.CreateUser(username, email);

            // Assert
            Assert.AreEqual(result, user);
        }
    }
}
