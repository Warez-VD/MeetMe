using System.IO;
using MeetMe.Data.Models;
using MeetMe.Web.Models.Profile;

namespace MeetMe.Services.Contracts
{
    public interface IAccountService
    {
        AspIdentityUser CreateUser(string username, string email);

        void Register(string firstName, string lastName, string id, string path);

        void ChangeProfileImage(Stream inputFileStream, int id);

        CustomUser EditProfile(ProfilePersonalnfo personalInfo);
    }
}
