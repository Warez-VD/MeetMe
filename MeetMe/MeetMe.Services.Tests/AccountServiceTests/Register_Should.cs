using NUnit.Framework;
using Moq;
using MeetMe.Services.Contracts;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using System.Drawing;

namespace MeetMe.Services.Tests.AccountServiceTests
{
    [TestFixture]
    public class Register_Should
    {
        [Test]
        public void CallImageService_GetImageOnce()
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

            string firstName = "some";
            string lastName = "other";
            string id = "asdf-dsg";
            string path = "test-path";

            // Act
            accountService.Register(firstName, lastName, id, path);

            // Assert
            mockedImageService.Verify(x => x.GetImage(It.Is<string>(p => p == path)), Times.Once);
        }

        [Test]
        public void CallProfileLogoFactory_CreateProfileImageOnce()
        {
            // Arrange
            var mockedAspIdentityUserFactory = new Mock<IAspIdentityUserFactory>();
            var mockedUserFactory = new Mock<ICustomUserFactory>();
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedImageService = new Mock<IImageService>();
            byte[] content = new byte[] { 12, 43, 54, 66 };
            mockedImageService.Setup(x => x.ImageToByteArray(It.IsAny<Image>())).Returns(content);
            var mockedProfileLogoFactory = new Mock<IProfileLogoFactory>();

            var accountService = new AccountService(
                mockedAspIdentityUserFactory.Object,
                mockedUserFactory.Object,
                mockedUserRepository.Object,
                mockedUnitOfWork.Object,
                mockedImageService.Object,
                mockedProfileLogoFactory.Object);

            string firstName = "some";
            string lastName = "other";
            string id = "asdf-dsg";
            string path = "test-path";

            // Act
            accountService.Register(firstName, lastName, id, path);

            // Assert
            mockedProfileLogoFactory.Verify(x => x.CreateProfileImage(It.Is<byte[]>(c => c == content)), Times.Once);
        }

        [Test]
        public void CallUserFactory_CreateCustomUserOnce()
        {
            // Arrange
            var mockedAspIdentityUserFactory = new Mock<IAspIdentityUserFactory>();
            var mockedUserFactory = new Mock<ICustomUserFactory>();
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedImageService = new Mock<IImageService>();
            var mockedProfileLogoFactory = new Mock<IProfileLogoFactory>();
            var logo = new ProfileImage();
            mockedProfileLogoFactory.Setup(x => x.CreateProfileImage(It.IsAny<byte[]>())).Returns(logo);

            var accountService = new AccountService(
                mockedAspIdentityUserFactory.Object,
                mockedUserFactory.Object,
                mockedUserRepository.Object,
                mockedUnitOfWork.Object,
                mockedImageService.Object,
                mockedProfileLogoFactory.Object);

            string firstName = "some";
            string lastName = "other";
            string id = "asdf-dsg";
            string path = "test-path";

            // Act
            accountService.Register(firstName, lastName, id, path);

            // Assert
            mockedUserFactory
                .Verify(
                    x => x.CreateCustomUser(
                        It.Is<string>(f => f == firstName),
                        It.Is<string>(l => l == lastName),
                        It.Is<string>(i => i == id),
                        It.Is<ProfileImage>(p => p == logo)),
                        Times.Once);
        }

        [Test]
        public void CallUserRepository_AddOnce()
        {
            // Arrange
            var mockedAspIdentityUserFactory = new Mock<IAspIdentityUserFactory>();
            var mockedUserFactory = new Mock<ICustomUserFactory>();
            var user = new CustomUser();
            mockedUserFactory
                .Setup(
                    x => x.CreateCustomUser(
                        It.IsAny<string>(),
                        It.IsAny<string>(),
                        It.IsAny<string>(),
                        It.IsAny<ProfileImage>())).Returns(user);
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

            string firstName = "some";
            string lastName = "other";
            string id = "asdf-dsg";
            string path = "test-path";

            // Act
            accountService.Register(firstName, lastName, id, path);

            // Assert
            mockedUserRepository.Verify(x => x.Add(It.Is<CustomUser>(u => u == user)), Times.Once);
        }

        [Test]
        public void CallUnitOfWork_CommitOnce()
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

            string firstName = "some";
            string lastName = "other";
            string id = "asdf-dsg";
            string path = "test-path";

            // Act
            accountService.Register(firstName, lastName, id, path);

            // Assert
            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}
