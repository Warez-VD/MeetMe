using System.IO;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace MeetMe.Services.Tests.AccountServiceTests
{
    [TestFixture]
    public class ChangeProfileImage_Should
    {
        [Test]
        public void CallImageService_GetByteArrayFromStreamOnce()
        {
            // Arrange
            var mockedAspIdentityUserFactory = new Mock<IAspIdentityUserFactory>();
            var mockedUserFactory = new Mock<ICustomUserFactory>();
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var user = new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 1, 2 } } };
            mockedUserRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(user);
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

            var stream = new MemoryStream();
            int id = 2;

            // Act
            accountService.ChangeProfileImage(stream, id);

            // Assert
            mockedImageService.Verify(x => x.GetByteArrayFromStream(It.Is<Stream>(s => s == stream)), Times.Once);
        }

        [Test]
        public void CallUserRepository_GetByIdOnce()
        {
            // Arrange
            var mockedAspIdentityUserFactory = new Mock<IAspIdentityUserFactory>();
            var mockedUserFactory = new Mock<ICustomUserFactory>();
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var user = new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 1, 2 } } };
            mockedUserRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(user);
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

            var stream = new MemoryStream();
            int id = 2;

            // Act
            accountService.ChangeProfileImage(stream, id);

            // Assert
            mockedUserRepository.Verify(x => x.GetById(It.Is<int>(i => i == id)), Times.Once);
        }

        [Test]
        public void CallUserRepository_UpdateWithUpdatedImageContent()
        {
            // Arrange
            var mockedAspIdentityUserFactory = new Mock<IAspIdentityUserFactory>();
            var mockedUserFactory = new Mock<ICustomUserFactory>();
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var user = new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 1, 2 } } };
            mockedUserRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(user);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedImageService = new Mock<IImageService>();
            var imageContent = new byte[] { 2, 5, 10 };
            mockedImageService.Setup(x => x.GetByteArrayFromStream(It.IsAny<Stream>())).Returns(imageContent);
            var mockedProfileLogoFactory = new Mock<IProfileLogoFactory>();

            var accountService = new AccountService(
                mockedAspIdentityUserFactory.Object,
                mockedUserFactory.Object,
                mockedUserRepository.Object,
                mockedUnitOfWork.Object,
                mockedImageService.Object,
                mockedProfileLogoFactory.Object);

            var stream = new MemoryStream();
            int id = 2;

            // Act
            accountService.ChangeProfileImage(stream, id);

            // Assert
            mockedUserRepository.Verify(x => x.Update(It.Is<CustomUser>(u => u == user && user.ProfileImage.Content == imageContent)), Times.Once);
        }

        [Test]
        public void CallUnitOfWork_CommitOnce()
        {
            // Arrange
            var mockedAspIdentityUserFactory = new Mock<IAspIdentityUserFactory>();
            var mockedUserFactory = new Mock<ICustomUserFactory>();
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var user = new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 1, 2 } } };
            mockedUserRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(user);
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

            var stream = new MemoryStream();
            int id = 2;

            // Act
            accountService.ChangeProfileImage(stream, id);

            // Assert
            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}
