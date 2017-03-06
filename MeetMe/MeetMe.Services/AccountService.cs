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
        private readonly IRepository<CustomUser> userRepository;
        private readonly IUnitOfWork unitOfWork;

        public AccountService(
            IAspIdentityUserFactory aspIdentityUserFactory,
            ICustomUserFactory userFactory,
            IRepository<CustomUser> userRepository,
            IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(aspIdentityUserFactory, "AspIdentityUserFactory").IsNull().Throw();
            Guard.WhenArgument(userFactory, "UserFactory").IsNull().Throw();
            Guard.WhenArgument(userRepository, "UserRepository").IsNull().Throw();
            Guard.WhenArgument(userFactory, "UnitOfWork").IsNull().Throw();

            this.aspIdentityUserFactory = aspIdentityUserFactory;
            this.userFactory = userFactory;
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }

        public AspIdentityUser CreateUser(string username, string email)
        {
            var identityUser = this.aspIdentityUserFactory.CreateAspIdentityUser(username, email);
            return identityUser;
        }

        public void Register(string firstName, string lastName, string id)
        {
            var user = this.userFactory.CreateCustomUser(firstName, lastName, id);
            this.userRepository.Add(user);
            this.unitOfWork.Commit();
        }
    }
}
