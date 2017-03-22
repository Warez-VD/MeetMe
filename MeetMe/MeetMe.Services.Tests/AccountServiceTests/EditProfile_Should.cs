using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using MeetMe.Web.Models.Profile;
using Moq;
using NUnit.Framework;

namespace MeetMe.Services.Tests.AccountServiceTests
{
    [TestFixture]
    public class EditProfile_Should
    {
        [Test]
        public void CallUserRepository_GetByIdOnce()
        {
            // Arrange
            var mockedAspIdentityUserFactory = new Mock<IAspIdentityUserFactory>();
            var mockedUserFactory = new Mock<ICustomUserFactory>();
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var user = new CustomUser();
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
            int id = 1;
            var personalInfo = new ProfilePersonalnfo() { Id = id };

            // Act
            accountService.EditProfile(personalInfo);

            // Assert
            mockedUserRepository.Verify(x => x.GetById(It.Is<int>(i => i == id)), Times.Once);
        }

        [Test]
        public void CallUserRepository_UpdateWithUpdatedUserProperties()
        {
            // Arrange
            var mockedAspIdentityUserFactory = new Mock<IAspIdentityUserFactory>();
            var mockedUserFactory = new Mock<ICustomUserFactory>();
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var user = new CustomUser();
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
            int id = 1;
            string firstName = "Some name";
            string lastName = "Other name";
            int age = 15;
            string city = "Pekin";
            string school = "Some school";
            string company = "Some company";
            var personalInfo = new ProfilePersonalnfo()
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                City = city,
                School = school,
                Company = company
            };

            // Act
            accountService.EditProfile(personalInfo);

            // Assert
            mockedUserRepository
                .Verify(
                    x => x.Update(
                        It.Is<CustomUser>(
                            u => u == user &&
                            user.FirstName == firstName &&
                            user.LastName == lastName &&
                            user.Age == age &&
                            user.City == city &&
                            user.School == school &&
                            user.Company == company)),
                        Times.Once);
        }

        [Test]
        public void CallUnitOfWork_CommitOnce()
        {
            // Arrange
            var mockedAspIdentityUserFactory = new Mock<IAspIdentityUserFactory>();
            var mockedUserFactory = new Mock<ICustomUserFactory>();
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var user = new CustomUser();
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
            int id = 1;
            var personalInfo = new ProfilePersonalnfo() { Id = id };

            // Act
            accountService.EditProfile(personalInfo);

            // Assert
            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void ReturnCorrectUser()
        {
            // Arrange
            var mockedAspIdentityUserFactory = new Mock<IAspIdentityUserFactory>();
            var mockedUserFactory = new Mock<ICustomUserFactory>();
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var user = new CustomUser();
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
            int id = 5;
            var personalInfo = new ProfilePersonalnfo() { Id = id };

            // Act
            var result = accountService.EditProfile(personalInfo);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<CustomUser>(result);
        }
    }
}
