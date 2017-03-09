using MeetMe.Services.Contracts;
using MeetMe.Data.Models;
using Bytes2you.Validation;
using MeetMe.Data.Contracts;

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
            Guard.WhenArgument(userFactory, "UnitOfWork").IsNull().Throw();
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
            var user = this.userFactory.CreateCustomUser(firstName, lastName, id, profileLogo);
            this.userRepository.Add(user);
            this.unitOfWork.Commit();
        }
    }
}
