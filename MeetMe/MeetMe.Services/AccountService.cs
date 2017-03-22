using System;
using System.IO;
using Bytes2you.Validation;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using MeetMe.Web.Models.Profile;

namespace MeetMe.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAspIdentityUserFactory aspIdentityUserFactory;
        private readonly ICustomUserFactory userFactory;
        private readonly IEFRepository<CustomUser> userRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IImageService imageService;
        private readonly IProfileLogoFactory profileLogoFactory;

        public AccountService(
            IAspIdentityUserFactory aspIdentityUserFactory,
            ICustomUserFactory userFactory,
            IEFRepository<CustomUser> userRepository,
            IUnitOfWork unitOfWork,
            IImageService imageService,
            IProfileLogoFactory profileLogoFactory)
        {
            Guard.WhenArgument(aspIdentityUserFactory, "AspIdentityUserFactory").IsNull().Throw();
            Guard.WhenArgument(userFactory, "UserFactory").IsNull().Throw();
            Guard.WhenArgument(userRepository, "UserRepository").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "UnitOfWork").IsNull().Throw();
            Guard.WhenArgument(imageService, "ImageService").IsNull().Throw();
            Guard.WhenArgument(profileLogoFactory, "ProfileLogoFactory").IsNull().Throw();

            this.aspIdentityUserFactory = aspIdentityUserFactory;
            this.userFactory = userFactory;
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
            this.imageService = imageService;
            this.profileLogoFactory = profileLogoFactory;
        }

        public AspIdentityUser CreateUser(string username, string email)
        {
            var identityUser = this.aspIdentityUserFactory.CreateAspIdentityUser(username, email);
            return identityUser;
        }

        public void Register(string firstName, string lastName, string id, string path)
        {
            var image = this.imageService.GetImage(path);
            var convertedImage = this.imageService.ImageToByteArray(image);
            var profileLogo = this.profileLogoFactory.CreateProfileImage(convertedImage);
            string fullname = $"{firstName} {lastName}";
            var user = this.userFactory.CreateCustomUser(firstName, lastName, fullname, id, profileLogo);
            this.userRepository.Add(user);
            this.unitOfWork.Commit();
        }

        public void ChangeProfileImage(Stream inputFileStream, int id)
        {
            var fileContent = this.imageService.GetByteArrayFromStream(inputFileStream);
            var user = this.userRepository.GetById(id);
            user.ProfileImage.Content = fileContent;
            this.userRepository.Update(user);
            this.unitOfWork.Commit();
        }

        public CustomUser EditProfile(ProfilePersonalnfo personalInfo)
        {
            var user = this.userRepository.GetById(personalInfo.Id);
            user.FirstName = personalInfo.FirstName;
            user.LastName = personalInfo.LastName;
            user.Age = personalInfo.Age;
            user.City = personalInfo.City;
            user.School = personalInfo.School;
            user.Company = personalInfo.Company;

            this.userRepository.Update(user);
            this.unitOfWork.Commit();
            return user;
        }
    }
}
