using MeetMe.Data.Models;

namespace MeetMe.Services.Contracts
{
    public interface IProfileLogoFactory
    {
        ProfileImage CreateProfileImage(byte[] content);
    }
}
