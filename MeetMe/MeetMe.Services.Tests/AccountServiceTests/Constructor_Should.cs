using System;
using NUnit.Framework;
using Moq;
using MeetMe.Services.Contracts;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;

namespace MeetMe.Services.Tests.AccountServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhen_AspIdentityUserFactoryIsNull()
        {
            // Arrange
            var mockedUserFactory = new Mock<ICustomUserFactory>();
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedImageService = new Mock<IImageService>();
            var mockedProfileLogoFactory = new Mock<IProfileLogoFactory>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new AccountService(
                null,
                mockedUserFactory.Object,
                mockedUserRepository.Object,
                mockedUnitOfWork.Object,
                mockedImageService.Object,
                mockedProfileLogoFactory.Object));

            // Assert
            Assert.That(ex.Message.Contains("AspIdentityUserFactory"));
        }

        [Test]
        public void ThrowsWhen_UserFactoryIsNull()
        {
            // Arrange
            var mockedAspIdentityUserFactory = new Mock<IAspIdentityUserFactory>();
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedImageService = new Mock<IImageService>();
            var mockedProfileLogoFactory = new Mock<IProfileLogoFactory>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new AccountService(
                mockedAspIdentityUserFactory.Object,
                null,
                mockedUserRepository.Object,
                mockedUnitOfWork.Object,
                mockedImageService.Object,
                mockedProfileLogoFactory.Object));

            // Assert
            Assert.That(ex.Message.Contains("UserFactory"));
        }

        [Test]
        public void ThrowsWhen_UserRepositoryIsNull()
        {
            // Arrange
            var mockedAspIdentityUserFactory = new Mock<IAspIdentityUserFactory>();
            var mockedUserFactory = new Mock<ICustomUserFactory>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedImageService = new Mock<IImageService>();
            var mockedProfileLogoFactory = new Mock<IProfileLogoFactory>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new AccountService(
                mockedAspIdentityUserFactory.Object,
                mockedUserFactory.Object,
                null,
                mockedUnitOfWork.Object,
                mockedImageService.Object,
                mockedProfileLogoFactory.Object));

            // Assert
            Assert.That(ex.Message.Contains("UserRepository"));
        }

        [Test]
        public void ThrowsWhen_UnitOfWorkIsNull()
        {
            // Arrange
            var mockedAspIdentityUserFactory = new Mock<IAspIdentityUserFactory>();
            var mockedUserFactory = new Mock<ICustomUserFactory>();
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var mockedImageService = new Mock<IImageService>();
            var mockedProfileLogoFactory = new Mock<IProfileLogoFactory>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new AccountService(
                mockedAspIdentityUserFactory.Object,
                mockedUserFactory.Object,
                mockedUserRepository.Object,
                null,
                mockedImageService.Object,
                mockedProfileLogoFactory.Object));

            // Assert
            Assert.That(ex.Message.Contains("UnitOfWork"));
        }

        [Test]
        public void ThrowsWhen_ImageServiceIsNull()
        {
            // Arrange
            var mockedAspIdentityUserFactory = new Mock<IAspIdentityUserFactory>();
            var mockedUserFactory = new Mock<ICustomUserFactory>();
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedProfileLogoFactory = new Mock<IProfileLogoFactory>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new AccountService(
                mockedAspIdentityUserFactory.Object,
                mockedUserFactory.Object,
                mockedUserRepository.Object,
                mockedUnitOfWork.Object,
                null,
                mockedProfileLogoFactory.Object));

            // Assert
            Assert.That(ex.Message.Contains("ImageService"));
        }

        [Test]
        public void ThrowsWhen_ProfileLogoFactoryIsNull()
        {
            // Arrange
            var mockedAspIdentityUserFactory = new Mock<IAspIdentityUserFactory>();
            var mockedUserFactory = new Mock<ICustomUserFactory>();
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedImageService = new Mock<IImageService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new AccountService(
                mockedAspIdentityUserFactory.Object,
                mockedUserFactory.Object,
                mockedUserRepository.Object,
                mockedUnitOfWork.Object,
                mockedImageService.Object,
                null));

            // Assert
            Assert.That(ex.Message.Contains("ProfileLogoFactory"));
        }

        [Test]
        public void ReturnInstanceOfAccountService_Correct()
        {
            // Arrange
            var mockedAspIdentityUserFactory = new Mock<IAspIdentityUserFactory>();
            var mockedUserFactory = new Mock<ICustomUserFactory>();
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedImageService = new Mock<IImageService>();
            var mockedProfileLogoFactory = new Mock<IProfileLogoFactory>();

            // Act
            var accountService = new AccountService(
                mockedAspIdentityUserFactory.Object,
                mockedUserFactory.Object,
                mockedUserRepository.Object,
                mockedUnitOfWork.Object,
                mockedImageService.Object,
                mockedProfileLogoFactory.Object);

            // Assert
            Assert.IsNotNull(accountService);
            Assert.IsInstanceOf<AccountService>(accountService);
        }
    }
}
