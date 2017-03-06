using MeetMe.Services.Contracts;
using MeetMe.Data.Models;
using Bytes2you.Validation;

namespace MeetMe.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAspIdentityUserFactory aspIdentityUserFactory;
        private readonly IUserFactory userFactory;

        public AccountService(
            IAspIdentityUserFactory aspIdentityUserFactory,
            IUserFactory userFactory)
        {
            Guard.WhenArgument(aspIdentityUserFactory, "AspIdentityUserFactory").IsNull().Throw();
            Guard.WhenArgument(userFactory, "UserFactory").IsNull().Throw();

            this.aspIdentityUserFactory = aspIdentityUserFactory;
            this.userFactory = userFactory;
        }

        public AspIdentityUser CreateUser(string username, string email)
        {
            var identityUser = this.aspIdentityUserFactory.CreateAspIdentityUser(username, email);
            return identityUser;
        }

        public void Register(string firstName, string lastName, string id)
        {
            var user = this.userFactory.CreateUser(firstName, lastName, id);
            //repo commit
        }
    }
}
